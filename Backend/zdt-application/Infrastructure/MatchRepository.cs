using Microsoft.EntityFrameworkCore;
using zdt_application.Data;
using zdt_application.Models;

namespace zdt_application.Infrastructure
{
    public class MatchRepository : IMatchRepository
    {
        private readonly DBContext _dbContext;

        public MatchRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddClickedMatch(MostClickedMatch clickedMatch)
        {
            try
            {
                await _dbContext.AddAsync(clickedMatch);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task AddComment(UserComment comment)
        {
            try
            {
                await _dbContext.UserComments.AddAsync(comment);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<int> CountRatingForMatch(int matchId)
        {
            try
            {
                return await _dbContext.MatchRatings.CountAsync(r => r.MatchId == matchId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateRatingAsync(MatchRating userPrediction)
        {
            try
            {
                _dbContext.AddAsync(userPrediction);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateRatingsAsync(List<UserResultPrediction> ratingsToAdd)
        {
            try
            {
                _dbContext.UserResultPredictions.AddRangeAsync(ratingsToAdd);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateUserPrediction(UserMatchPrediction userPrediction)
        {
            try
            {
                await _dbContext.AddAsync(userPrediction);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteComment(UserComment userComment)
        {
            try
            {
                _dbContext.Remove(userComment);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<MatchRating>> GetAllMatchRating()
        {
            try
            {
                return await _dbContext.MatchRatings.OrderByDescending(x => x.Rate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MostClickedMatch> GetClickedMatch(int matchId)
        {
            try
            {
                return await _dbContext.ClickedMatches.Where(m => m.MatchId == matchId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserComment> GetCommentAsync(Guid commentId)
        {
            try
            {
                return await _dbContext.UserComments.Where(x => x.Id == commentId).FirstOrDefaultAsync();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<MatchRating> GetMatchRatingAsync(string userId, int matchId)
        {
            try
            {
                return await _dbContext.MatchRatings.Where(p => p.UserId == userId && p.MatchId == matchId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<MostClickedMatch>> GetMostClickedMatch()
        {
            try
            {
                return await _dbContext.ClickedMatches.OrderByDescending(x => x.Clicked).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserResultPrediction> GetUserPrediction(Guid predictionId)
        {
            try
            {
                return await _dbContext.UserResultPredictions.Where(p => p.Id == predictionId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserMatchPrediction> GetUserPredictionByUserAndMatchId(string userId, int matchId)
        {
            try
            {
                return await _dbContext.UserMatchPredictions.Where(p => p.UserId == userId && p.MatchId == matchId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserResultPrediction> GetUserPredictionByUserId(string userId)
        {
            try
            {
                return await _dbContext.UserResultPredictions.Where(p => p.UserId == userId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveUserPrediction(UserResultPrediction prediction)
        {
            try
            {
                _dbContext.UserResultPredictions.Remove(prediction);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> SumRatingForMatch(int matchId)
        {
            try
            {
                return (int)await _dbContext.MatchRatings.Where(r => r.MatchId == matchId).SumAsync(x => x.Rate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateClickedMatch(MostClickedMatch isMatchClicked)
        {
            try
            {
                _dbContext.Update(isMatchClicked);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateCommentAsync(UserComment userComment)
        {
            try
            {
                _dbContext.Update(userComment);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateResultPredictionAsync(UserResultPrediction prediction)
        {
            try
            {
                _dbContext.Update(prediction);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        Task<MostClickedMatch> IMatchRepository.GetMostClickedMatch()
        {
            throw new NotImplementedException();
        }
    }
}