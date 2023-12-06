using System.Text;
using Newtonsoft.Json;
using SpecFlowZdt.Support;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class RegisterSteps
    {
            private readonly HttpClient _httpClient = new HttpClient();
            private HttpResponseMessage _response;

            [Given(@"the registration endpoint is available")]
            public async Task GivenTheRegistrationEndpointIsAvailable()
            {
                _response = await _httpClient.GetAsync("https://localhost:7205/api/Base");
            }

            [When(@"I send a POST request to the register endpoint with the following data:")]
            public async Task WhenISendPOSTRequestToRegisterEndpointWithTheFollowingData(Table table)
            {
                var registerModel = table.CreateInstance<RegisterModel>();
                var content = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");
                _response = await _httpClient.PostAsync("https://localhost:7205/api/Authenticate/register", content);
            }

            [Then(@"the response status code should be (\d+) OK")]
            public void ThenTheResponseStatusCodeShouldBeOK(int statusCode)
            {
                Assert.Equal(200, (int)_response.StatusCode);
            }
            /*
            [And(@"the response should contain the message ""(.*)""")]
            public async Task ThenTheResponseShouldContainTheMessage(string expectedMessage)
            {
                var responseContent = await _response.Content.ReadAsStringAsync();
                Assert.Contains(expectedMessage, responseContent);
            }
            */
    }
}
