using zdt_application.Models;

namespace zdt_application.Infrastructure
{
    public interface IMatchRepository
    {
        Task AddClickedMatch(MostClickedMatch clickedMatch);
        Task AddComment(UserComment model);
        Task<int> CountRatingForMatch(int matchId);
        Task CreateRatingAsync(MatchRating userPrediction);
        Task CreateRatingsAsync(List<UserResultPrediction> ratingsToAdd);
        Task CreateUserPrediction(UserMatchPrediction userPrediction);
        Task DeleteComment(UserComment userComment);
        Task<List<MatchRating>> GetAllMatchRating();
        Task<MostClickedMatch> GetClickedMatch(int matchId);
        Task<UserComment> GetCommentAsync(Guid commentId);
        Task<MatchRating> GetMatchRatingAsync(string userId, int matchId);
        Task<MostClickedMatch> GetMostClickedMatch();
        Task<UserResultPrediction> GetUserPrediction(Guid predictionId);
        Task<UserMatchPrediction> GetUserPredictionByUserAndMatchId(string userId, int matchId);
        Task<UserResultPrediction> GetUserPredictionByUserId(string userId);
        Task RemoveUserPrediction(UserResultPrediction predictionId);
        Task<int> SumRatingForMatch(int matchId);
        Task UpdateClickedMatch(MostClickedMatch isMatchClicked);
        Task UpdateCommentAsync(UserComment userComment);
        Task UpdateResultPredictionAsync(UserResultPrediction prediction);
    }
}