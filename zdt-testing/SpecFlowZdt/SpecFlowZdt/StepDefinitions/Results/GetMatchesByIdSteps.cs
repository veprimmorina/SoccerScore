using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetMatchesByIdSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the external API is available for matches by ID")]
        public async Task GivenTheExternalAPIIsAvailableForMatchesById()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get matches by ID endpoint with the ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetMatchesByIdEndpointWithTheId(string id)
        {
            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/YourControllerName/getMatchesById/{id}");
        }

        [Then(@"the response status code should be (\d+) OK for retrieving matches by ID")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingMatchesById(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
