using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class MostClickedMatchSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for retrieving most clicked matches")]
        public async Task GivenTheApplicationIsAvailableForRetrievingMostClickedMatches()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get most clicked matches endpoint")]
        public async Task WhenISendGETRequestToGetMostClickedMatchesEndpoint()
        {
            var url = $"{_apiHelper.GetApi()}/Results/getMostClickedMatches";
            _response = await _httpClient.GetAsync(url);
        }

        [Then(@"the response status code should be (\d+) OK for retrieving most clicked matches successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingMostClickedMatchesSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
