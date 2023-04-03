using SpecFlow.Actions.Playwright;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightExample.PageObjects;
using Playwright.FluentAssertions;
using System;


namespace Example.PageObjects
{
    /// <summary>
    /// Calculator Page Object
    /// </summary>
    public class LoginPageObject : BasePage
    {
        
        private IPage _page;
        // The page URL

        private protected const string LoginUrl = "https://automationexercise.com/login";

        //Finding elements by ID
        private static string LoginEmail => "[data-qa=login-email]";
        private static string LoginPassword => "[data-qa=login-password]";
        private static string LoginButton => "[data-qa=login-button]";

        private static string ResultElement => "[data-qa=login-button]";
       

        public async Task EnterLoginEmailAsync(string value)
        {
            //Enter text
            var emailInput = await _page.QuerySelectorAsync(LoginEmail);

            if (emailInput != null)
            {
                await emailInput.FillAsync(value);
            }
            
        }

        public async Task EnterLoginPasswordAsync(string value)
        {
            //Enter text
            var passwordInput = await _page.QuerySelectorAsync(LoginPassword);

            if (passwordInput != null)
            {
                await passwordInput.FillAsync(value);
            }
        }

        public async Task ClickLoginAsync()
        {
            //Click the add button
             await _page.ClickAsync(LoginButton);
            
        }

        public async Task EnsureLoginIsOpenAndResetAsync()
        {
            
            //Open the Login page in the browser if not opened yet
            if (_page.Url != LoginUrl)
            {
                await _page.GotoAsync(LoginUrl);
            }
            //Otherwise do the same thing
            else
            {
                
                 await _page.GotoAsync(LoginUrl);
            }
        }
       
        public async Task VerfiyLoginAsync()
        {
            
            // Check for successful login element
            var loggedInElement = await _page.QuerySelectorAsync("a i.fa.fa-user + b");

            // Check if element exists and contains the correct username
            if (loggedInElement != null)
            {
                Console.WriteLine("Login successful");
                // Add any additional assertions or actions to perform after successful login
            }
            else
            {
                Console.WriteLine("Login failed");
                // Add any actions to perform after failed login, such as throwing an exception or logging the error
            }
          
            
        }

        public LoginPageObject(IPage page) : base(page)
        {
            _page = page;
        }
    }
}