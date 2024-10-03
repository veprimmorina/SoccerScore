using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class EditResultPredictionSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for editing user result predictions")]
        public async Task GivenTheApplicationIsAvailableForEditingUserResultPredictions()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a PUT request to the edit result prediction endpoint with the following data:")]
        public async Task WhenISendPUTRequestToEditResultPredictionEndpointWithTheFollowingData(Table table)
        {
            foreach (var row in table.Rows)
            {
                var predictionId = Guid.Parse(row["PredictionId"]);
                var homeScore = int.Parse(row["HomeScore"]);
                var awayScore = int.Parse(row["AwayScore"]);

                var url = $"{_apiHelper.GetApi()}/Results/editUserPredictionWithResult?predictionId={predictionId}&homeScore={homeScore}&awayScore={awayScore}";

                _response = await _httpClient.PutAsync(url, null);
            }
        }

        [Then(@"the response status code should be (\d+) OK for editing user result predictions successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForEditingUserResultPredictionsSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
