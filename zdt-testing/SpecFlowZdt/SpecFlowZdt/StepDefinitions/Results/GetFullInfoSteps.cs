using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetFullInfoSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available")]
        public async Task GivenTheExternalAPIIsAvailable()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get full information endpoint")]
        public async Task WhenISendGETRequestToGetFullInformationEndpoint()
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving full information")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingFullInformation(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
