using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class EditCommentSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for editing a comment")]
        public async Task GivenTheApplicationIsAvailableForEditingComment()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a PUT request to the edit comment endpoint with the comment ID ""(.*)"" and new comment content ""(.*)""")]
        public async Task WhenISendPUTRequestToEditCommentEndpointWithTheCommentIdAndNewCommentContent(Guid commentId, string newComment)
        {
            var url = $"{_apiHelper.GetApi()}/Results/edit/comment/{commentId}/?comment={newComment}";
            _response = await _httpClient.PutAsync(url, null);
        }

        [Then(@"the response status code should be (\d+) OK for editing the comment successfully")]
        public void ThenTheResponseStatusCodeShouldBeOKForEditingTheCommentSuccessfully(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
