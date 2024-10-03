using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetAllSeasonMatchesByLeagueIdSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for all season matches by league ID")]
        public async Task GivenTheExternalAPIIsAvailableForAllSeasonMatchesByLeagueId()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get all season matches by league ID endpoint with the league ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetAllSeasonMatchesByLeagueIdEndpointWithTheLeagueId(string id)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results/getAllSeasonMatchesByLeagueId/{id}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving all season matches by league ID")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingAllSeasonMatchesByLeagueId(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
