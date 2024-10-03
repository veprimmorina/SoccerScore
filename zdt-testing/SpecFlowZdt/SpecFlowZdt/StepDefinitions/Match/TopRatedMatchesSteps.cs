using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions.League
{
    [Binding]
    public class TopRatedMatchesSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for retrieving top-rated matches")]
        public async Task GivenTheApplicationIsAvailableForRetrievingTopRatedMatches()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a GET request to the get top-rated matches endpoint")]
        public async Task WhenISendGETRequestToGetTopRatedMatchesEndpoint()
        {
            var url = $"{_apiHelper.GetApi()}/Results/getTopRatedMatches";
            _response = await _httpClient.GetAsync(url);
        }

        [Then(@"the response status code should be (\d+) OK for retrieving top-rated matches successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForRetrievingTopRatedMatchesSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
