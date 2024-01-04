using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class PinLeagueSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for pinning a league")]
        public async Task GivenTheApplicationIsAvailableForPinningLeague()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a POST request to the pin league endpoint with the user ID ""(.*)"" and league ID ""(.*)""")]
        public async Task WhenISendPOSTRequestToPinLeagueEndpointWithTheUserIdAndLeagueId(string userId, int leagueId)
        {
            var url = $"{_apiHelper.GetApi()}/Results/pinLeague/{userId}/{leagueId}";
            _response = await _httpClient.PostAsync(url, null);
        }

        [Then(@"the response status code should be (\d+) OK for pinning the league successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForPinningTheLeagueSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
