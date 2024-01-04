using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetPlayerInfoByNameSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for player information by name")]
        public async Task GivenTheExternalAPIIsAvailableForPlayerInfoByName()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get player information by name endpoint with the name ""(.*)""")]
        public async Task WhenISendGETRequestToGetPlayerInfoByNameEndpointWithTheName(string playerName)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Results/getPlayerInfoByName/{playerName}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving player information by name")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingPlayerInfoByName(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
