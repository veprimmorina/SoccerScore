using Newtonsoft.Json;
using SpecFlowZdt.Support;
using System.Text;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"the application is available for logging in with username and password")]
        public async Task GivenTheApplicationIsAvailableForLoggingInWithUsernameAndPassword()
        {
            _response = await _apiHelper.GetAsync(_apiHelper.GetApi() + "/Base");
        }

        [When(@"I send a POST request to the login endpoint with the following data:")]
        public async Task WhenISendPOSTRequestToLoginEndpointWithTheFollowingData(Table table)
        {
            var loginModel = table.CreateInstance<LoginModel>();
            var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
            _response = await _httpClient.PostAsync(_apiHelper.GetApi() + "/Authenticate/LoginWithUsernameAndPassword", content);
        }

        [Then(@"the response status code should be (\d+) OK for successful login")]
        public async Task ThenTheResponseStatusCodeShouldBeOKForSuccessfulLogin(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
