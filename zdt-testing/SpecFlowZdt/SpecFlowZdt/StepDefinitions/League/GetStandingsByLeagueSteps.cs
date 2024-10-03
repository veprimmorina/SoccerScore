using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetStandingsByLeagueSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for league standings by ID")]
        public async Task GivenTheExternalAPIIsAvailableForStandingsByLeagueId()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get league standings by ID endpoint with the league ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetStandingsByLeagueIdEndpointWithTheLeagueId(string leagueId)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results/getLeagueStandingsById/{leagueId}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving league standings by ID")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingStandingsByLeagueId(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
