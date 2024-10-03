using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zdt_application.Application.Services;
using zdt_application.Controllers.Base;

namespace zdt_application.Controllers
{
    public class LeagueController : BaseController
    {
        private readonly ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [AllowAnonymous]
        [HttpGet("getTeamByName/{teamName}")]
        public async Task<IActionResult> GetTeamInfo(string teamName)
        {
            var result = await _leagueService.GetTeamInfo(teamName);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("getLeagueById/{id}")]
        public async Task<IActionResult> GetLeagueInfo(string id)
        {
            var result = await _leagueService.GetLeagueInfo(id);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("getLeagueStandingsById/{id}")]
        public async Task<IActionResult> GetStandingsByLeague(string id)
        {
            var result = await _leagueService.GetStandingsByLeague(id);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpPost("pinLeague/{userId}/{leagueId}")]
        public async Task<IActionResult> PinLeague(string userId, int leagueId)
        {
            var result = await _leagueService.PinLeague(userId, leagueId);
            return CreateResponse(result);
        }
    }
}