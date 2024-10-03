using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetPlayersByTeamSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for players by team ID")]
        public async Task GivenTheExternalAPIIsAvailableForPlayersByTeamId()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get players by team ID endpoint with the team ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetPlayersByTeamIdEndpointWithTheTeamId(string teamId)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results/getPlayersByTeamId/{teamId}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving players by team ID")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingPlayersByTeamId(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
