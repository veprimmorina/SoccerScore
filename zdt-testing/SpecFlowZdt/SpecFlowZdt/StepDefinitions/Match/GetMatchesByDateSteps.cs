using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions.League
{
    [Binding]
    public class GetMatchesByDateSteps
    {
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the main application is available")]
        public async Task GivenTheApplicationIsAvailable()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get matches by date endpoint with specified date ""(.*)""")]
        public async Task WhenISendGETRequestToGetMatchesByDateEndpointWithDate(string date)
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + $"/results/getMatchesByDate/{date}");
        }

        [Then(@"the response status code should be (\d+) OK")]
        public void ThenTheResponseStatusCodeShouldBeOK(int statusCode)
        {
            Assert.Equal(200, (int)_response.StatusCode);
        }
    }
}
