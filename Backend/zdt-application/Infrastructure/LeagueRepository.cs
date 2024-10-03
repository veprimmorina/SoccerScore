using Microsoft.EntityFrameworkCore;
using zdt_application.Data;
using zdt_application.Models;

namespace zdt_application.Infrastructure
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly DBContext _dbContext;

        public LeagueRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLeague(PinnedLeagues pinnedLeague)
        {
            try
            {
                _dbContext.PinnedLeagues.Add(pinnedLeague);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeletePinnedLeagueAsync(UserLeague isLeaguePinnedForUser)
        {
            try
            {
                _dbContext.UserPinnedLeagues.Remove(isLeaguePinnedForUser);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserLeague> GetPinnedLeagueForUserAsync(string userId, int leagueId)
        {
            try
            {
               return await _dbContext.UserPinnedLeagues
                     .Where(upl => upl.UserId == userId && upl.PinnedLeagues.LeagueId == leagueId)
                     .FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task PinLeagueForUserAsync(UserLeague userPinnedLeagues)
        {
            try
            {
                _dbContext.UserPinnedLeagues.Add(userPinnedLeagues);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
