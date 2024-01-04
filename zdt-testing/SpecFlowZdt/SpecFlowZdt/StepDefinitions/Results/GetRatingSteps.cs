using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetRatingSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for retrieving ratings")]
        public async Task GivenTheApplicationIsAvailableForRetrievingRatings()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get rating endpoint with the match ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetRatingEndpointWithTheMatchId(int matchId)
        {
            var url = $"{_apiHelper.GetApi()}/Results/getRating/{matchId}";
            _response = await _httpClient.GetAsync(url);
        }

        [Then(@"the response status code should be (\d+) OK for retrieving ratings successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingRatingsSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
