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
            private ApiHelper _apiHelper = new ApiHelper();

            [Given(@"the application is available for registration")]
            public async Task GivenTheApplicationIsAvailableForRegistration()
            {
                _response = await _httpClient.GetAsync(_apiHelper.GetApi()+"/Base");
            }

            [When(@"I send a POST request to the register endpoint with the following data:")]
            public async Task WhenISendPOSTRequestToRegisterEndpointWithTheFollowingData(Table table)
            {
                var registerModel = table.CreateInstance<RegisterModel>();
                var content = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");
                _response = await _httpClient.PostAsync(_apiHelper.GetApi()+"/Authenticate/register", content);
            }

            [Then(@"the response status code should be (\d+) OK for registration")]
            public void ThenTheResponseStatusCodeShouldBeOKForRegistration(int statusCode)
            {
                Assert.Equal(200, (int)_response.StatusCode);
            }
    }
}
