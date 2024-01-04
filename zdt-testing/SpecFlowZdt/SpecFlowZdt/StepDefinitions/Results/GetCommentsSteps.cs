using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class GetCommentsSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for retrieving comments")]
        public async Task GivenTheApplicationIsAvailableForRetrievingComments()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get comments endpoint with the match ID ""(.*)""")]
        public async Task WhenISendGETRequestToGetCommentsEndpointWithTheMatchId(int matchId)
        {
            var url = $"{_apiHelper.GetApi()}/Results/get/comments/{matchId}";
            _response = await _httpClient.GetAsync(url);
        }

        [Then(@"the response status code should be (\d+) OK for retrieving comments successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingCommentsSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
