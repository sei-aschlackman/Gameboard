// Copyright 2021 Carnegie Mellon University. All Rights Reserved.
// Released under a MIT (SEI)-style license. See LICENSE.md in the project root for license information.

using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gameboard.Api.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TopoMojo.Api.Client;

namespace Gameboard.Api.Services
{
    public class ChallengeSpecService : _Service
    {
        IChallengeSpecStore Store { get; }
        ITopoMojoApiClient Mojo { get; }

        public ChallengeSpecService(
            ILogger<ChallengeSpecService> logger,
            IMapper mapper,
            CoreOptions options,
            IChallengeSpecStore store,
            ITopoMojoApiClient mojo
        ) : base(logger, mapper, options)
        {
            Store = store;
            Mojo = mojo;
        }

        public async Task<ChallengeSpec> AddOrUpdate(NewChallengeSpec model)
        {
            var entity = await Store.List().FirstOrDefaultAsync(s =>
                s.ExternalId == model.ExternalId &&
                s.GameId == model.GameId
            );

            if (entity is Data.ChallengeSpec)
            {
                Mapper.Map(model, entity);
                await Store.Update(entity);
            }
            else
            {
                entity = Mapper.Map<Data.ChallengeSpec>(model);
                await Store.Create(entity);
            }

            return Mapper.Map<ChallengeSpec>(entity);
        }

        public async Task<ChallengeSpec> Retrieve(string id)
        {
            return Mapper.Map<ChallengeSpec>(await Store.Retrieve(id));
        }

        public async Task Update(ChangedChallengeSpec account)
        {
            var entity = await Store.Retrieve(account.Id);
            Mapper.Map(account, entity);

            await Store.Update(entity);
        }

        public async Task Delete(string id)
        {
            await Store.Delete(id);
        }

        public async Task<ExternalSpec[]> List(SearchFilter model)
        {

            var results = await Mojo.ListWorkspacesAsync(
                "", "", null, null,
                model.Term, model.Skip, model.Take, model.Sort,
                model.Filter
            );

            return Mapper.Map<ExternalSpec[]>(
                results
            );
        }

        public async Task Sync(string id)
        {
            var externals = (await List(new SearchFilter()))
                .ToDictionary(o => o.ExternalId)
            ;

            foreach (var spec in Store.DbSet.Where(s => s.GameId == id))
            {
                if (externals.ContainsKey(spec.ExternalId).Equals(false))
                    continue;

                spec.Name = externals[spec.ExternalId].Name;
                spec.Description = externals[spec.ExternalId].Description;
            }

            await Store.DbContext.SaveChangesAsync();
        }
    }
}
