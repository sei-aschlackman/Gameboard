// Copyright 2021 Carnegie Mellon University. All Rights Reserved.
// Released under a MIT (SEI)-style license. See LICENSE.md in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gameboard.Api.Data.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TopoMojo.Api.Client;
using Alloy.Api.Client;

namespace Gameboard.Api.Services
{
    public class GameEngineService : _Service
    {
        IChallengeStore Store { get; }
        ITopoMojoApiClient Mojo { get; }
        IAlloyApiClient Alloy { get; }

        private IMemoryCache _localcache;
        private ConsoleActorMap _actorMap;

        public GameEngineService(
            ILogger<ChallengeService> logger,
            IMapper mapper,
            CoreOptions options,
            IChallengeStore store,
            ITopoMojoApiClient mojo,
            IMemoryCache localcache,
            ConsoleActorMap actorMap,
            IAlloyApiClient alloy
        ) : base(logger, mapper, options)
        {
            Store = store;
            Mojo = mojo;
            _localcache = localcache;
            _actorMap = actorMap;
            Alloy = alloy;
        }

        public async Task<GameState> RegisterGamespace(Data.ChallengeSpec spec, NewChallenge model, Data.Game game,
        Data.Player player, Data.Challenge entity, int playerCount, string graderKey, string graderUrl)
        {
            GameState state = null;

            if (spec.GameEngineType == GameEngineType.Crucible)
            {
                var additionalUserIds = new List<Guid>();

                if (game.AllowTeam)
                {
                    additionalUserIds = await Store.DbContext.Players
                        .Where(x => x.TeamId == player.TeamId && x.Id != player.Id)
                        .Select(x => new Guid(x.UserId))
                        .ToListAsync();
                }

                var evt = await Alloy.CreateEventFromEventTemplateAsync(spec.ExternalId, new Guid(player.UserId), player.ApprovedName, additionalUserIds);

                while (evt.Status != EventStatus.Active && evt.Status != EventStatus.Ended && evt.Status != EventStatus.Expired)
                {
                    evt = await Alloy.GetEventAsync(evt.Id);
                    await Task.Delay(5000);
                }

                state = new GameState
                {
                    Markdown = spec.Description,
                    IsActive = true,
                    Players = new List<TopoMojo.Api.Client.Player>
                    {
                        new TopoMojo.Api.Client.Player
                        {
                            GamespaceId = evt.Id.ToString(),
                            SubjectId = player.TeamId,
                            SubjectName = player.ApprovedName
                        }
                    },
                    Vms = new List<VmState>(),
                    Name = spec.Name,
                    Id = entity.Id
                };

                var virtualMachines = await Alloy.GetEventVirtualMachinesAsync(evt.Id);

                foreach (var virtualMachine in virtualMachines)
                {
                    state.Vms.Add(new VmState
                    {
                        Id = virtualMachine.Url,
                        Name = virtualMachine.Name,
                        IsVisible = true,
                        IsRunning = true,
                        IsolationId = virtualMachine.Id
                    });
                }

                var questions = await Alloy.GetEventQuestionsAsync(evt.Id);
                entity.Points = (int)questions.Sum(x => x.Weight);

                state.Challenge = new ChallengeView()
                {
                    Attempts = 0,
                    MaxAttempts = 10,
                    MaxPoints = entity.Points,
                    Score = 0,
                    SectionCount = 0,
                    SectionIndex = 0,
                    SectionScore = 0,
                    SectionText = "Section 1",
                    Text = "Answer the questions",
                    Questions = new List<TopoMojo.Api.Client.QuestionView>()
                };

                foreach (var question in questions)
                {
                    state.Challenge.Questions.Add(new TopoMojo.Api.Client.QuestionView
                    {
                        Text = question.Text,
                        Weight = question.Weight
                    });
                }
            }
            else
            {
                state = await Mojo.RegisterGamespaceAsync(new GamespaceRegistration
                {
                    Players = new RegistrationPlayer[] {
                        new RegistrationPlayer {
                            SubjectId = player.TeamId,
                            SubjectName = player.Name
                        }
                    },
                    ResourceId = entity.ExternalId,
                    Variant = model.Variant,
                    Points = spec.Points,
                    MaxAttempts = game.MaxAttempts,
                    StartGamespace = true,
                    ExpirationTime = entity.Player.SessionEnd,
                    GraderKey = graderKey,
                    GraderUrl = graderUrl,
                    PlayerCount = playerCount
                });
            }

            return state;
        }

        public async Task<GameState> GetPreview(Data.ChallengeSpec spec)
        {
            GameState state = null;

            if (spec.GameEngineType == GameEngineType.Crucible)
            {
                state = new GameState();
                var eventTemplate = await Alloy.GetEventTemplateAsync(new Guid(spec.ExternalId));
                state.Markdown = eventTemplate.Description;
            }
            else
            {
                state = await Mojo.PreviewGamespaceAsync(spec.ExternalId);
            }

            return state;
        }

        public async Task<GameState> GradeChallenge(Data.Challenge entity, SectionSubmission model)
        {
            Task<GameState> gradingTask;

            if (entity.GameEngineType == GameEngineType.Crucible)
            {
                gradingTask = GradeCrucibleChallengeAsync(entity, model);
            }
            else
            {
                gradingTask = Mojo.GradeChallengeAsync(model);
            }

            return await gradingTask;
        }

        public async Task<GameState> RegradeChallenge(Data.Challenge entity)
        {
            if (entity.GameEngineType == GameEngineType.TopoMojo)
            {
                return await Mojo.RegradeChallengeAsync(entity.Id);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<ConsoleSummary> GetConsole(Data.Challenge entity, ConsoleRequest model, bool observer)
        {
            switch (model.Action)
            {
                case ConsoleAction.Ticket:
                    {
                        if (entity.GameEngineType == GameEngineType.TopoMojo)
                        {
                            return Mapper.Map<ConsoleSummary>(
                                await Mojo.GetVmTicketAsync(model.Id)
                            );
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }

                case ConsoleAction.Reset:
                    {
                        if (entity.GameEngineType == GameEngineType.TopoMojo)
                        {
                            var vm = await Mojo.ChangeVmAsync(
                                new VmOperation
                                {
                                    Id = model.Id,
                                    Type = VmOperationType.Reset
                                }
                            );

                            return new ConsoleSummary
                            {
                                Id = vm.Id,
                                Name = vm.Name,
                                SessionId = model.SessionId,
                                IsRunning = vm.State == VmPowerState.Running,
                                IsObserver = observer
                            };
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
            }

            return null;
        }

        public async Task<SectionSubmission[]> AuditChallenge(Data.Challenge entity)
        {
            if (entity.GameEngineType == GameEngineType.TopoMojo)
            {
                return (await Mojo.AuditChallengeAsync(entity.Id)).ToArray();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private async Task<GameState> GradeCrucibleChallengeAsync(Data.Challenge entity, SectionSubmission model)
        {
            var challenge = Mapper.Map<Challenge>(entity);
            var eventId = challenge.State.Players.FirstOrDefault().GamespaceId;

            if (challenge.State.Challenge.Attempts >= challenge.State.Challenge.MaxAttempts)
            {
                throw new ActionForbidden();
            }

            var questionViews = await Alloy.GradeEventAsync(new Guid(eventId), model.Questions.Select(x => x.Answer));
            var grade = questionViews.Where(x => x.IsCorrect && x.IsGraded).Sum(x => x.Weight);

            var state = challenge.State;
            state.Challenge.LastScoreTime = DateTime.UtcNow;
            state.Challenge.Score = grade;
            state.Challenge.Attempts++;
            state.Id = entity.Id;

            if (grade == state.Challenge.MaxPoints ||
                challenge.State.Challenge.Attempts >= challenge.State.Challenge.MaxAttempts)
            {
                state.IsActive = false;
                state.EndTime = DateTimeOffset.UtcNow;

                await Alloy.EndEventAsync(new Guid(eventId));
            }

            state.Challenge.Questions.Clear();

            foreach (var questionView in questionViews)
            {
                state.Challenge.Questions.Add(new TopoMojo.Api.Client.QuestionView
                {
                    Answer = questionView.Answer,
                    IsCorrect = questionView.IsCorrect,
                    IsGraded = questionView.IsGraded,
                    Text = questionView.Text,
                    Weight = questionView.Weight
                });
            }

            return state;
        }

        public async Task<ExternalSpec[]> ListSpecs(SearchFilter model)
        {
            var resultsList = new List<ExternalSpec>();

            var tasks = new List<Task>();
            Task<ICollection<WorkspaceSummary>> mojoTask = null;
            Task<ICollection<EventTemplate>> crucibleTask = null;

            try
            {
                if (Options.MojoEnabled)
                {
                    mojoTask = Mojo.ListWorkspacesAsync(
                    "", "", null, null,
                    model.Term, model.Skip, model.Take, model.Sort,
                    model.Filter);

                    tasks.Add(mojoTask);
                }

                crucibleTask = Crucible.ListSpecs();
                tasks.Add(crucibleTask);

                await Task.WhenAll(tasks);
            }
            catch (Exception) { }

            if (mojoTask != null && mojoTask.IsCompletedSuccessfully)
            {
                resultsList.AddRange(Mapper.Map<ExternalSpec[]>(
                    mojoTask.Result
                ));
            }

            if (crucibleTask != null && crucibleTask.IsCompletedSuccessfully)
                resultsList.AddRange(crucibleTask.Result);

            return resultsList.ToArray();
        }

        public async Task<GameState> LoadGamespace(Data.Challenge entity)
        {
            if (entity.GameEngineType == GameEngineType.TopoMojo)
            {
                return await Mojo.LoadGamespaceAsync(entity.Id);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<GameState> StartGamespace(Data.Challenge entity)
        {
            if (entity.GameEngineType == GameEngineType.TopoMojo)
            {
                return await Mojo.StartGamespaceAsync(entity.Id);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<GameState> StopGamespace(Data.Challenge entity)
        {
            if (entity.GameEngineType == GameEngineType.TopoMojo)
            {
                return await Mojo.StopGamespaceAsync(entity.Id);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task DeleteGamespace(Data.Challenge entity)
        {
            if (entity.GameEngineType == GameEngineType.TopoMojo)
            {
                await Mojo.DeleteGamespaceAsync(entity.Id);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
