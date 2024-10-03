using zdt_application.Application.Wrappers;
using zdt_application.DTOs;
using zdt_application.DTOs.Matches;

namespace zdt_application.Application.Services
{
    public interface IMatchesService
    {
        public Task<BaseResponse<string>> GetAllMatches();
        public Task<BaseResponse<string>> GetMatchesByDate(string date);
        public Task<BaseResponse<string>> GetMatchesById(string id);
        public Task<BaseResponse<string>> GetAllSeasonMatchesByLeagueId(string leagueId);
        public Task<BaseResponse<string>> AddComment(string userId, int matchId, string comment);
        public Task<BaseResponse<string>> EditComment(Guid commentId, string comment);
        public Task<BaseResponse<string>> DeleteComment(Guid commentId);
        public Task<BaseResponse<string>> PredictMatch(string userId, int matchId, int prediction);
        public Task<BaseResponse<string>> RateMatch(string userId, int matchId, double rate);
        public Task<BaseResponse<int>> GetRating(int matchId);
        public Task<BaseResponse<string>> ClickedMatch(int matchId);
        public Task<BaseResponse<List<MostClickedMatchDto>>> MostClickedMatch();
        public Task<BaseResponse<List<MatchRatingDto>>> TopRatedMatches();
        public Task<BaseResponse<string>> PredictWithResultMatches(List<UserResultPredictionDto> matchesPredictions);
        public Task<BaseResponse<UserPredictionDto>> GetPredictionWithResultMatches(string userId);
        public Task<BaseResponse<string>> EditResultPrediction(Guid predictionId, int? homeScore, int? awayScore);
        public Task<BaseResponse<string>> DeleteResultPrediction(Guid predictionId);
    }
}