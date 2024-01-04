using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class ClickedMatchSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for clicking on a match")]
        public async Task GivenTheApplicationIsAvailableForClickingOnMatch()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a POST request to the click match endpoint with the match ID ""(.*)""")]
        public async Task WhenISendPOSTRequestToClickMatchEndpointWithTheMatchId(int matchId)
        {
            var url = $"{_apiHelper.GetApi()}/Results/click/{matchId}";
            _response = await _httpClient.PostAsync(url, null);
        }

        [Then(@"the response status code should be (\d+) OK for clicking on the match successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForClickingOnTheMatchSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
