
using zdt_application.Models;

namespace zdt_application.Infrastructure
{
    public interface ILeagueRepository
    {
        Task AddLeague(PinnedLeagues pinnedLeague);
        Task DeletePinnedLeagueAsync(UserLeague isLeaguePinnedForUser);
        Task<UserLeague> GetPinnedLeagueForUserAsync(string userId, int leagueId);
        Task PinLeagueForUserAsync(UserLeague userPinnedLeagues);
    }
}
