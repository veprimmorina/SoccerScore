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
            // You might want to implement a login step here, 
            // or ensure that the user is already logged in before testing logout.
            // This might involve making a login request and storing the JWT token.
            // For simplicity, I'll assume the user is already logged in.
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
