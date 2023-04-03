using Example.PageObjects;
using FluentAssertions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Example.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        //Page Object for Login
        private readonly LoginPageObject _LoginPageObject;

        public LoginStepDefinitions(LoginPageObject LoginPageObject)
        {
            _LoginPageObject = LoginPageObject;
        }

        [Given(@"enter the email ""(.*)""")]
        public async Task GivenTheEmailAsync(string value)
        {
            //delegate to Page Object
            await _LoginPageObject.EnterLoginEmailAsync(value);
        }

        
        [Given(@"enter the password ""(.*)""")]
        public async Task GivenThePasswordAsync(string value)
        {
            //delegate to Page Object
            await _LoginPageObject.EnterLoginPasswordAsync(value);
        }

        


       [When(@"click the login button")]
        public async Task WhenClickLgoinButtonAsync()
        {
            //delegate to Page Object
            await _LoginPageObject.ClickLoginAsync();
        }


        [Then(@"the result should be successful")]
        public async Task ThenTheResultShouldBeAsync()
        {
            //delegate to Page Object
            await _LoginPageObject.VerfiyLoginAsync();
            
        }
    }
}