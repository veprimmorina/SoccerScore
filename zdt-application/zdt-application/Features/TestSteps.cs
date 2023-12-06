using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;
using Xunit;
using zdt_application.Auth;
using zdt_application.Controllers;
using zdt_application.Models;

namespace zdt_application.Features
{
    public class TestSteps
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthenticateController _controller;
        private IActionResult _result;

        public TestSteps(UserManager<ApplicationUser> userManager, AuthenticateController controller)
        {
            _userManager = userManager;
            _controller = controller;
        }

        [Given(@"a user with username ""(.*)"" does not exist")]
        public async Task GivenAUserWithUsernameDoesNotExist(string username)
        {
            var userExists = await _userManager.FindByNameAsync(username);
            Assert.Null(userExists);
        }

        [When(@"I register a new user with the username ""(.*)"" and valid details")]
        public async Task WhenIRegisterANewUserWithTheUsernameAndValidDetails(string username)
        {
            var registerModel = new RegisterModel
            {
                Username = username,
                Name = "Test",
                Surname = "est",
                PhoneNumber = "38344444444",
                Email = $"{username}@example.com",
                Password = "P@ssw0rd", 
                ConfirmationPassword = "P@ssw0rd",
            };

            _result = await _controller.Register(registerModel);
        }

        [Then(@"the registration should be successful")]
        public void ThenTheRegistrationShouldBeSuccessful()
        {
            Assert.IsType<OkObjectResult>(_result);
        }

    }
}
