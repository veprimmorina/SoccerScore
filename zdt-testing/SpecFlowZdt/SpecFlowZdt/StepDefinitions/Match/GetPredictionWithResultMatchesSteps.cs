using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetPredictionWithResultMatchesSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for retrieving user predictions with results")]
        public async Task GivenTheApplicationIsAvailableForRetrievingUserPredictionsWithResults()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get user prediction with result matches endpoint with the following data:")]
        public async Task WhenISendGETRequestToGetUserPredictionWithResultMatchesEndpointWithTheFollowingData(Table table)
        {
            foreach (var row in table.Rows)
            {
                var userId = row["UserId"];
                var url = $"{_apiHelper.GetApi()}/Results/getUserPredictionWithResult?userId={userId}";
                _response = await _httpClient.GetAsync(url);
            }
        }

        [Then(@"the response status code should be (\d+) OK for retrieving user predictions with results successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingUserPredictionsWithResultsSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
