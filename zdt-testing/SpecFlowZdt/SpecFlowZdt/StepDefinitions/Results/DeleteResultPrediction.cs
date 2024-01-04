using SpecFlowZdt.Support;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class DeleteResultPredictionSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for deleting user result predictions")]
        public async Task GivenTheApplicationIsAvailableForDeletingUserResultPredictions()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a DELETE request to the delete result prediction endpoint with the following data:")]
        public async Task WhenISendDELETERequestToDeleteResultPredictionEndpointWithTheFollowingData(Table table)
        {
            foreach (var row in table.Rows)
            {
                var predictionId = Guid.Parse(row["PredictionId"]);

                var url = $"{_apiHelper.GetApi()}/Results/deleteUserPredictionWithResult?predictionId={predictionId}";
                _response = await _httpClient.DeleteAsync(url);
            }
        }

        [Then(@"the response status code should be (\d+) OK for deleting user result predictions successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForDeletingUserResultPredictionsSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
