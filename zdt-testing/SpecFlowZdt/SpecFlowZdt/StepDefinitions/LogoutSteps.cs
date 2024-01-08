using SpecFlowZdt.Support;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class LogoutSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the user is logged in")]
        public async Task GivenTheUserIsLoggedIn()
        {
            
        }

        [When(@"I send a GET request to the logout endpoint")]
        public async Task WhenISendGETRequestToLogoutEndpoint()
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer your_token_here");
            _response = await _httpClient.GetAsync(_apiHelper.GetApi() + "/Authenticate/Logout");
        }

        [Then(@"the response status code should be (\d+) OK for logout")]
        public void ThenTheResponseStatusCodeShouldBeOKForLogout(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
