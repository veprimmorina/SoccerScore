using zdt_application.Application.Wrappers;

namespace zdt_application.Application.Services
{
    public interface ILeagueService
    {
        public Task<BaseResponse<string>> GetTeamInfo(string teamName);
        public Task<BaseResponse<string>> GetLeagueInfo(string id);
        public Task<BaseResponse<string>> GetStandingsByLeague(string id);
        public Task<BaseResponse<string>> PinLeague(string userId, int leagueId);
    }
}