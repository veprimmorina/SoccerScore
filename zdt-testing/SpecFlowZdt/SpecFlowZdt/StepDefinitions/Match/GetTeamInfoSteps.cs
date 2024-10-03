using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetTeamInfoSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for team information by team name")]
        public async Task GivenTheExternalAPIIsAvailableForTeamInfoByTeamName()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get team information endpoint with the team name ""(.*)""")]
        public async Task WhenISendGETRequestToGetTeamInformationEndpointWithTheTeamName(string teamName)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results/getTeamByName/{teamName}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving team information")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingTeamInformation(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
