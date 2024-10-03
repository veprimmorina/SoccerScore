using Microsoft.AspNetCore.Identity;
using zdt_application.Application.Services.Base;
using zdt_application.Application.Wrappers;
using zdt_application.Auth;
using zdt_application.Infrastructure;
using zdt_application.Models;

namespace zdt_application.Application.Services
{
    public class LeagueService : BaseService, ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public LeagueService(ILeagueRepository leagueRepository, UserManager<ApplicationUser> userManager)
        {
            _leagueRepository = leagueRepository;
            _userManager = userManager;
        }

        public async Task<BaseResponse<string>> GetLeagueInfo(string id)
        {
            string url = $"{BaseUrl}/league/basic?api_key={ApiKey}&leagueId={id}";
            return await MakeHttpRequest(url);
        }

        public async Task<BaseResponse<string>> GetStandingsByLeague(string id)
        {
            string url = $"{BaseUrl}/standing/league?api_key={ApiKey}&leagueId={id}";
            return await MakeHttpRequest(url);
        }

        public async Task<BaseResponse<string>> GetTeamInfo(string teamName)
        {
            string url = $"{BaseUrl}/team/search?api_key={ApiKey}&name={teamName}";
            return await MakeHttpRequest(url);
        }

        public async Task<BaseResponse<string>> PinLeague(string userId, int leagueId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var league = new PinnedLeagues
            {
                LeagueId = leagueId
            };

            if (user == null || league == null)
            {
                return BaseResponse<string>.NotFound("User or League not found");
            }

            var isLeaguePinnedForUser = await _leagueRepository.GetPinnedLeagueForUserAsync(userId, leagueId);

            if (isLeaguePinnedForUser != null)
            {
            await _leagueRepository.DeletePinnedLeagueAsync(isLeaguePinnedForUser);
            return BaseResponse<string>.Success("League unpinned successfully");
            }

            await _leagueRepository.AddLeague(league);

            var userPinnedLeagues = new UserLeague()
            {
                UserId = userId,
                PinnedLeaguesId = league.Id
            };

            await _leagueRepository.PinLeagueForUserAsync(userPinnedLeagues);

            return BaseResponse<string>.Success("League pinned successfully");
        }
    }
}