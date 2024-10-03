using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions.League
{
    [Binding]
    public class GetLeagueInfoSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for league information by ID")]
        public async Task GivenTheExternalAPIIsAvailableForLeagueInfoById()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get league information endpoint with the ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetLeagueInformationEndpointWithTheId(string id)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results/getLeagueById/{id}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving league information")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingLeagueInformation(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
