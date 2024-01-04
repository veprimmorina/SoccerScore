using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetPlayerInfoByIdSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for player information by ID")]
        public async Task GivenTheExternalAPIIsAvailableForPlayerInfoById()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get player information by ID endpoint with the player ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetPlayerInfoByIdEndpointWithThePlayerId(string playerId)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results/getPlayerInfoById/{playerId}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving player information by ID")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingPlayerInfoById(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
