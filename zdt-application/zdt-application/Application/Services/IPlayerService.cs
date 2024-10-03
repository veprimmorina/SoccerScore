using zdt_application.Application.Wrappers;

namespace zdt_application.Application.Services
{
    public interface IPlayerService
    {
        public Task<BaseResponse<string>> GetPlayersByTeam(string id);
        public Task<BaseResponse<string>> GetPlayerStatsByLeague(string id);
        public Task<BaseResponse<string>> GetTopScorersByLeague(string id);
        public Task<BaseResponse<string>> GetPlayerInfoById(string id);
        public Task<BaseResponse<string>> GetPlayerInfoByName(string name);
    }
}
