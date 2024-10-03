using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class DeleteCommentSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for deleting a comment")]
        public async Task GivenTheApplicationIsAvailableForDeletingComment()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a DELETE request to the delete comment endpoint with the comment ID ""(.*)""")]
        public async Task WhenISendDELETERequestToDeleteCommentEndpointWithTheCommentId(Guid commentId)
        {
            var url = $"{_apiHelper.GetApi()}/Results/delete/comment/{commentId}";
            _response = await _httpClient.DeleteAsync(url);
        }

        [Then(@"the response status code should be (\d+) OK for deleting the comment successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForDeletingTheCommentSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
