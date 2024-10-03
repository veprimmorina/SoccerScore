using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zdt_application.Application.Services;
using zdt_application.Controllers.Base;

namespace zdt_application.Controllers
{
    public class PlayerController : BaseController
    {
        public readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [AllowAnonymous]
        [HttpGet("getPlayerInfoByName/{name}")]
        public async Task<IActionResult> GetPlayerInfoByName(string name)
        {
            var result = await _playerService.GetPlayerInfoByName(name);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("getPlayerInfoById/{id}")]
        public async Task<IActionResult> GetPlayerInfoById(string id)
        {
            var result = await _playerService.GetPlayerInfoById(id);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("getTopScoresByLeague/{id}")]
        public async Task<IActionResult> GetTopScorersByLeague(string id)
        {
            var result = await _playerService.GetTopScorersByLeague(id);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("getPlayerStatsByLeagueId/{id}")]
        public async Task<IActionResult> GetPlayerStatsByLeague(string id)
        {
            var result = await _playerService.GetPlayerStatsByLeague(id);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("getPlayersByTeamId/{id}")]
        public async Task<IActionResult> GetPlayersByTeam(string id)
        {
            var result = await _playerService.GetPlayersByTeam(id);
            return CreateResponse(result);
        }
    }
}
