using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions.League
{
    [Binding]
    public class PredictMatchSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for predicting a match")]
        public async Task GivenTheApplicationIsAvailableForPredictingMatch()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a POST request to the predict match endpoint with the user ID ""(.*)"", match ID ""(.*)"", and prediction ""(.*)""")]
        public async Task WhenISendPOSTRequestToPredictMatchEndpointWithTheUserIdMatchIdAndPrediction(string userId, int matchId, int prediction)
        {
            var url = $"{_apiHelper.GetApi()}/Results/predict/{userId}/{matchId}/{prediction}";
            _response = await _httpClient.PostAsync(url, null);
        }

        [Then(@"the response status code should be (\d+) OK for predicting the match successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForPredictingTheMatchSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
