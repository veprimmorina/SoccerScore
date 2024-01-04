using SpecFlowZdt.Support;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowZdt.StepDefinitions.Results
{
    [Binding]
    public class Comment
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();
        private CommentModel _commentModel;

        [Given(@"the application is available for commenting")]
        public async Task IsApplicationAvailable()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a POST request to the commenting endpoint with the following data")]
        public async Task SendRequest(Table table)
        {
            _commentModel = table.CreateInstance<CommentModel>();
            var endpoint = $"/comment/{_commentModel.Userid}/{_commentModel.MatchId}/{_commentModel.Comment}";
            _response = await _apiHelper.PostAsync(_apiHelper.GetApi() + endpoint, null);
        }

        [Then(@"the response status code should be 200 OK for posting comment")]
        public void IsEqual(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
