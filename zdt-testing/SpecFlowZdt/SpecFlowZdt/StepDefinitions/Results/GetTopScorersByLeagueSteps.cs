using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetTopScorersByLeagueSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for top scorers by league ID")]
        public async Task GivenTheExternalAPIIsAvailableForTopScorersByLeagueId()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get top scorers by league ID endpoint with the league ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetTopScorersByLeagueIdEndpointWithTheLeagueId(string leagueId)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results/getTopScoresByLeague/{leagueId}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving top scorers by league ID")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingTopScorersByLeagueId(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
