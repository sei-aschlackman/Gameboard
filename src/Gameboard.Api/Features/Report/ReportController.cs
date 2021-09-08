using System.Threading.Tasks;
using Gameboard.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Gameboard.Api.Controllers
{

    [Authorize]
    public class ReportController: _Controller
    {
        public ReportController(
            ILogger<ReportController> logger,
            IDistributedCache cache,
            ReportService service
        ): base(logger, cache)
        {
            Service = service;
        }

        ReportService Service { get; }

        [HttpGet("/api/report/userstats")]
        [Authorize]
        public async Task<ActionResult<UserReport>> GetUserStats()
        {
            AuthorizeAny(
                () => Actor.IsAdmin
            );

            return Ok(await Service.GetUserStats());
        }

        [HttpGet("/api/report/playerstats")]
        [Authorize]
        public async Task<ActionResult<PlayerReport>> GetPlayerStats()
        {
            AuthorizeAny(
                () => Actor.IsAdmin
            );

            return Ok(await Service.GetPlayerStats());
        }

        [HttpGet("/api/report/sponsorstats")]
        [Authorize]
        public async Task<ActionResult<SponsorReport>> GetSponsorStats()
        {
            AuthorizeAny(
                () => Actor.IsAdmin
            );

            return Ok(await Service.GetSponsorStats());
        }

        [HttpGet("/api/report/gamesponsorstats")]
        [Authorize]
        public async Task<ActionResult<GameSponsorReport>> GetGameSponsorsStats(string[] gameIds)
        {
            AuthorizeAny(
                () => Actor.IsAdmin
            );

            return Ok(await Service.GetGameSponsorsStats(gameIds));
        }

        [HttpGet("/api/report/teamstats")]
        [Authorize]
        public async Task<ActionResult<TeamReport>> GetTeamStats()
        {
            AuthorizeAny(
                () => Actor.IsAdmin
            );

            return Ok(await Service.GetTeamStats());
        }
    }
}
