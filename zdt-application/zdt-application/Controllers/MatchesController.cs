using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zdt_application.Application.Services;
using zdt_application.Controllers.Base;
using zdt_application.Data;
using UserResultPredictionDto = zdt_application.DTOs.UserResultPredictionDto;

namespace zdt_application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : BaseController
    {
        private readonly IMatchesService _matchesService;

        public MatchesController(IMatchesService matchesService)
        {
            _matchesService = matchesService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetFullInfo()
        {
            var result = await _matchesService.GetAllMatches();
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("getMatchesByDate/{date}")]
        public async Task<IActionResult> GetMatchesByDate(string date)
        {
            var result = await _matchesService.GetMatchesByDate(date);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("getMatchesById/{id}")]
        public async Task<IActionResult> GetMatchesById(string id)
        {
            var result = await _matchesService.GetMatchesById(id);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("getAllSeasonMatchesByLeagueId/{id}")]
        public async Task<IActionResult> GetAllSeasonMatchesByLeagueId(string id)
        {
            var result = await _matchesService.GetAllSeasonMatchesByLeagueId(id);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpPut("edit/comment/{commentId}")]
        public async Task<IActionResult> EditComment(Guid commentId, string comment)
        {
            var result = await _matchesService.EditComment(commentId, comment);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpDelete("delete/comment/{commentId}")]
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            var result = await _matchesService.DeleteComment(commentId);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpPost("predict/{userId}/{matchId}/{prediction}")]
        public async Task<IActionResult> PredictMatch(string userId, int matchId, int prediction)
        {
            var result = await _matchesService.PredictMatch(userId, matchId, prediction);
            return CreateResponse(result);
        }

        [HttpPost("rateMatch/{userId}/{matchId}/{rate}")]
        public async Task<IActionResult> RateMatch(string userId, int matchId, double rate)
        {
            var result = await _matchesService.RateMatch(userId, matchId, rate);
            return CreateResponse(result);
        }

        [HttpGet("getRating/{matchId}")]
        public async Task<IActionResult> GetRating(int matchId)
        {
            var result = await _matchesService.GetRating(matchId);
            return CreateResponse(result);
        }

        [HttpPost("click/{matchId}")]
        public async Task<IActionResult> ClickedMatch(int matchId)
        {
            var result = await _matchesService.ClickedMatch(matchId);
            return CreateResponse(result);
        }

        [HttpGet("getMostClickedMatches")]
        public async Task<IActionResult> MostClickedMatch()
        {
            var result = await _matchesService.MostClickedMatch();
            return CreateResponse(result);
        }

        [HttpGet("getTopRatedMatches")]
        public async Task<IActionResult> TopRatedMatches()
        {
            var result = await _matchesService.TopRatedMatches();
            return CreateResponse(result);
        }

        [HttpPost("predictWithResult")]
        public async Task<IActionResult> PredictWithResultMatches(List<UserResultPredictionDto> matchesPredictions) 
        {
            var result = await _matchesService.PredictWithResultMatches(matchesPredictions);
            return CreateResponse(result);
        }
        [HttpGet("getUserPredictionWithResult")]
        public async Task<IActionResult> GetPredictionWithResultMatches(string userId)
        {
            var result = await _matchesService.GetPredictionWithResultMatches(userId);
            return CreateResponse(result);
        }

        [HttpPut("editUserPredictionWithResult")]
        public async Task<IActionResult> EditResultPrediction(Guid predictionId, int? homeScore, int? awayScore)
        {
            var result = await _matchesService.EditResultPrediction(predictionId, homeScore, awayScore);
            return CreateResponse(result);
        }

        [HttpDelete("deleteUserPredictionWithResult")]
        public async Task<IActionResult> DeleteResultPrediction(Guid predictionId)
        {
            var result = await _matchesService.DeleteResultPrediction(predictionId);
            return CreateResponse(result);
        }


        [HttpPost("addComment/userId/matchId/comment")]
        public async Task<IActionResult> AddComment(string userId, int matchId, string comment)
        {
            var result = await _matchesService.AddComment(userId, matchId, comment);
            return CreateResponse(result);
        }
    }
}