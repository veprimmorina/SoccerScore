using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetPlayerStatsByLeagueSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for player stats by league ID")]
        public async Task GivenTheExternalAPIIsAvailableForPlayerStatsByLeagueId()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get player stats by league ID endpoint with the league ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetPlayerStatsByLeagueIdEndpointWithTheLeagueId(string leagueId)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results/getPlayerStatsByLeagueId/{leagueId}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving player stats by league ID")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingPlayerStatsByLeagueId(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
