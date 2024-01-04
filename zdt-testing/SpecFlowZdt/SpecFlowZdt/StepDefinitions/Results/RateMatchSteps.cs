using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class RateMatchSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for rating a match")]
        public async Task GivenTheApplicationIsAvailableForRatingMatch()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a POST request to the rate match endpoint with the user ID ""(.*)"", match ID ""(.*)"", and rating ""(.*)""")]
        public async Task WhenISendPOSTRequestToRateMatchEndpointWithTheUserIdMatchIdAndRating(string userId, int matchId, double rating)
        {
            var url = $"{_apiHelper.GetApi()}/Results/rateMatch/{userId}/{matchId}/{rating}";
            _response = await _httpClient.PostAsync(url, null);
        }

        [Then(@"the response status code should be (\d+) OK for rating the match successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForRatingTheMatchSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
