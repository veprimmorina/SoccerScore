using zdt_application.Application.Services.Base;
using zdt_application.Application.Wrappers;

namespace zdt_application.Application.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
        public async Task<BaseResponse<string>> GetPlayerInfoById(string id)
        {
            string url = $"{BaseUrl}/player?api_key={ApiKey}&playerId={id}";
            return await MakeHttpRequest(url);
        }

        public async Task<BaseResponse<string>> GetPlayerInfoByName(string name)
        {
            string url = $"{BaseUrl}/player/search?api_key={ApiKey}&name={name}";
            return await MakeHttpRequest(url);
        }

        public async Task<BaseResponse<string>> GetPlayersByTeam(string id)
        {
            string url = $"{BaseUrl}/player/search?api_key={ApiKey}&id={id}";
            return await MakeHttpRequest(url);
        }

        public async Task<BaseResponse<string>> GetPlayerStatsByLeague(string id)
        {
            string url = $"{BaseUrl}/playerstats/league?api_key={ApiKey}leagueId={id}";
            return await MakeHttpRequest(url);
        }

        public async Task<BaseResponse<string>> GetTopScorersByLeague(string id)
        {
            string url = $"{BaseUrl}/player?api_key={ApiKey}&teamId={id}";
            return await MakeHttpRequest(url);
        }
    }
}
