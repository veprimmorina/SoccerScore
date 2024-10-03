using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions.League
{
    [Binding]
    public class GetPredictionSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for retrieving predictions")]
        public async Task GivenTheApplicationIsAvailableForRetrievingPredictions()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get prediction endpoint with the match ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetPredictionEndpointWithTheMatchId(int matchId)
        {
            var url = $"{_apiHelper.GetApi()}/Results/getPrediction/{matchId}";
            _response = await _httpClient.GetAsync(url);
        }

        [Then(@"the response status code should be (\d+) OK for retrieving predictions successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingPredictionsSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
