// Copyright 2021 Carnegie Mellon University. All Rights Reserved.
// Released under a MIT (SEI)-style license. See LICENSE.md in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gameboard.Api
{
    public class Player
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserApprovedName { get; set; }
        public string GameId { get; set; }
        public string GameName { get; set; }
        public string ApprovedName { get; set; }
        public string Name { get; set; }
        public string NameStatus { get; set; }
        public string Sponsor { get; set; }
        public string TeamSponsors { get; set; }
        public PlayerRole Role { get; set; }
        public DateTimeOffset SessionBegin { get; set; }
        public DateTimeOffset SessionEnd { get; set; }
        public int SessionMinutes { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }
        public long Time { get; set; }
        public int CorrectCount { get; set; }
        public int PartialCount { get; set; }
        public bool Advanced { get; set; }
        public bool IsManager { get; set; }
        public string[] SponsorList => (TeamSponsors ?? Sponsor).Split("|");
    }

    public class NewPlayer
    {
        public string UserId { get; set; }
        public string GameId { get; set; }
        public string Name { get; set; }
        public string Sponsor { get; set; }
    }

    public class ChangedPlayer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameStatus { get; set; }
        public string ApprovedName { get; set; }
        public string Sponsor { get; set; }
        public PlayerRole Role { get; set; }
    }

    public class SessionStartRequest
    {
        public string Id { get; set; }
    }

    public class SessionChangeRequest
    {
        public string TeamId { get; set; }
        public DateTimeOffset SessionEnd { get; set; }
    }

    public class SelfChangedPlayer
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class PlayerEnlistment
    {
        public string UserId { get; set; }
        public string PlayerId { get; set; }
        public string Code { get; set; }
    }

    public class Standing
    {
        public string TeamId { get; set; }
        public string ApprovedName { get; set; }
        public string Sponsor { get; set; }
        public string TeamSponsors { get; set; }
        public DateTimeOffset SessionBegin { get; set; }
        public DateTimeOffset SessionEnd { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }
        public long Time { get; set; }
        public int CorrectCount { get; set; }
        public int PartialCount { get; set; }
        public bool Advanced { get; set; }
        public string[] SponsorList => (TeamSponsors ?? Sponsor).Split("|");
    }

    public class TeamInvitation
    {
        public string Code { get; set; }
    }

    public class TeamAdvancement
    {
        public string[] TeamIds { get; set; }
        public string GameId { get; set; }
        public bool WithScores { get; set; }
        public string NextGameId { get; set; }
    }

    public class Team
    {
        public string TeamId { get; set; }
        public string ApprovedName { get; set; }
        public string GameId { get; set; }
        public string Sponsor { get; set; }
        public string TeamSponsors { get; set; }
        public DateTimeOffset SessionBegin { get; set; }
        public DateTimeOffset SessionEnd { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }
        public long Time { get; set; }
        public int CorrectCount { get; set; }
        public int PartialCount { get; set; }
        public bool Advanced { get; set; }
        public ICollection<TeamChallenge> Challenges { get; set; } = new List<TeamChallenge>();
        public ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();
        public string[] SponsorList => (TeamSponsors ?? Sponsor).Split("|");
    }

    public class TeamSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sponsor { get; set; }
        public string TeamSponsors { get; set; }
        public string[] Members { get; set; }
        public string[] SponsorList => (TeamSponsors ?? Sponsor).Split("|");
    }

    public class PlayerOverview
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string GameId { get; set; }
        public string GameName { get; set; }
        public string ApprovedName { get; set; }
    }

    public class PlayerDataFilter : SearchFilter
    {

        public const string FilterActiveOnly = "active";
        public const string FilterCompleteOnly = "complete";
        public const string FilterScoredOnly = "scored";
        public const string FilterAdvancedOnly = "advanced";
        public const string FilterDismissedOnly = "dismissed";
        public const string FilterCollapseTeams = "collapse";
        public const string NamePendingFilter = "pending";
        public const string NameDisallowedFilter = "disallowed";
        public const string SortRank = "rank";
        public const string SortTime = "time";
        public const string SortName = "name";
        public string tid { get; set; }
        public string gid { get; set; }
        public string uid { get; set; }
        public string org { get; set; }
        public bool WantsActive => Filter.Contains(FilterActiveOnly);
        public bool WantsComplete => Filter.Contains(FilterCompleteOnly);
        public bool WantsAdvanced => Filter.Contains(FilterAdvancedOnly);
        public bool WantsDismissed => Filter.Contains(FilterDismissedOnly);
        public bool WantsScored => Filter.Contains(FilterScoredOnly);
        public bool WantsGame => gid.NotEmpty();
        public bool WantsUser => uid.NotEmpty();
        public bool WantsTeam => tid.NotEmpty();
        public bool WantsOrg => org.NotEmpty();
        public bool WantsCollapsed => Filter.Contains(FilterCollapseTeams);
        public bool WantsPending => Filter.Contains(NamePendingFilter);
        public bool WantsDisallowed => Filter.Contains(NameDisallowedFilter);
        public bool WantsSortByTime => Sort == SortTime;
        public bool WantsSortByRank => Sort == SortRank || string.IsNullOrEmpty(Sort);
        public bool WantsSortByName => Sort == SortName;
    }

    public class BoardPlayer
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string UserId { get; set; }
        public string GameId { get; set; }
        public string ApprovedName { get; set; }
        public string Name { get; set; }
        public string NameStatus { get; set; }
        public string Sponsor { get; set; }
        public PlayerRole Role { get; set; }
        public DateTimeOffset SessionBegin { get; set; }
        public DateTimeOffset SessionEnd { get; set; }
        public int SessionMinutes { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }
        public long Time { get; set; }
        public int CorrectCount { get; set; }
        public int PartialCount { get; set; }
        public BoardGame Game { get; set; }
        public string ChallengeDocUrl { get; set; }
        public ICollection<Challenge> Challenges { get; set; } = new List<Challenge>();
        public bool IsManager => Role == PlayerRole.Manager;
    }

    public class TeamPlayer
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Name { get; set; }
        public string ApprovedName { get; set; }
        public string UserName { get; set; }
        public string UserApprovedName { get; set; }
        public string UserNameStatus { get; set; }
        public string Sponsor { get; set; }
        public PlayerRole Role { get; set; }
        public bool IsManager => Role == PlayerRole.Manager;
    }

    public class TeamState
    {
        public string TeamId { get; set; }
        public string ApprovedName { get; set; }
        public string Name { get; set; }
        public string NameStatus { get; set; }
        public DateTimeOffset SessionBegin { get; set; }
        public DateTimeOffset SessionEnd { get; set; }
    }

    public class PlayerCertificate
    {
        public Game Game { get; set; }
        public Player Player { get; set; }
        public string Html { get; set; }
    }
}
