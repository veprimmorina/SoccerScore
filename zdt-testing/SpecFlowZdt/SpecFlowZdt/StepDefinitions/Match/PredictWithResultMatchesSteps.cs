using Newtonsoft.Json;
using SpecFlowZdt.Support;
using System.Text;

namespace SpecFlowZdt.StepDefinitions.League
{
    [Binding]
    public class PredictWithResultMatchesSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for predicting matches with results")]
        public async Task GivenTheApplicationIsAvailableForPredictingMatchesWithResults()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a POST request to the predict with result matches endpoint with the following data:")]
        public async Task WhenISendPOSTRequestToPredictWithResultMatchesEndpointWithTheFollowingData(Table table)
        {
            var matchesPredictions = new List<UserResultPredictionDto>();

            foreach (var row in table.Rows)
            {
                matchesPredictions.Add(new UserResultPredictionDto
                {
                    UserId = row["UserId"],
                    MatchId = int.Parse(row["MatchId"]),
                    HomeScore = int.Parse(row["HomeScore"]),
                    AwayScore = int.Parse(row["AwayScore"])
                });
            }

            var content = new StringContent(JsonConvert.SerializeObject(matchesPredictions), Encoding.UTF8, "application/json");
            _response = await _httpClient.PostAsync(_apiHelper.GetApi() + "/Results/predictWithResult", content);
        }

        [Then(@"the response status code should be (\d+) OK for predicting matches with results successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForPredictingMatchesWithResultsSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
