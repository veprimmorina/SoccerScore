using SpecFlowZdt.Support;

namespace SpecFlowZdt.StepDefinitions
{
    [Binding]
    public class ConfirmEmailSteps
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private ApiHelper _apiHelper = new ApiHelper();

        [Given(@"a user with a confirmation code")]
        public async Task GivenAUserWithAConfirmationCode()
        {
            // You may need to implement a step to create a user and generate a confirmation code.
            // This might involve making a registration request and extracting the confirmation code.
            // For simplicity, I'll assume a user with a known confirmation code.
        }

        [When(@"I send a GET request to the confirm email endpoint with the following data:")]
        public async Task WhenISendGETRequestToConfirmEmailEndpointWithTheFollowingData(Table table)
        {
            var data = table.Rows[0];
            var userId = data["UserId"];
            var code = data["Code"];

            _response = await _httpClient.GetAsync($"{_apiHelper.GetApi()}/Authenticate/ConfirmEmail?userId={userId}&code={code}");
        }

        [Then(@"the response status code should be (\d+) OK for email confirmation")]
        public void ThenTheResponseStatusCodeShouldBeOKForEmailConfirmation(int statusCode)
        {
            Assert.Equal(statusCode, (int)_response.StatusCode);
        }
    }
}
