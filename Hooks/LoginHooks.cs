using Example.PageObjects;
using Microsoft.Playwright;
using System.Threading.Tasks;
using SpecFlow.Actions.Playwright;
using TechTalk.SpecFlow;

namespace Example.Hooks
{
    /// <summary>
    /// Login related hooks
    /// </summary>
    [Binding]
    public class LoginHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _traceName;

        public LoginHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _traceName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
        }

        ///<summary>
        ///  Reset the Login before each scenario tagged with "Login"
        /// </summary>
        [BeforeScenario(Order = 0)]
        public async Task BeforeScenarioAsync(BrowserDriver browserDriver)
        {
            var LoginPageObjectPage = await (await browserDriver.Current).NewPageAsync();

            var LoginPageObject = new LoginPageObject(LoginPageObjectPage);

            await LoginPageObject.EnsureLoginIsOpenAndResetAsync();


            _scenarioContext.ScenarioContainer.RegisterInstanceAs(LoginPageObject);
            
        }
        
        //[BeforeScenario(Order = 1000)]
        //public async Task StartTracingAsync(LoginPageObject LoginPageObject)
        //{
        //    var tracing = LoginPageObject.Page.Context.Tracing;
        //    await tracing.StartAsync(new TracingStartOptions
        //    {
        //        Name = _traceName,
        //        Screenshots = true,
        //        Snapshots = true
        //    });
        //}

        //[AfterScenario]
        //public async Task StopTracingAsync(LoginPageObject LoginPageObject)
        //{
        //    var tracing = LoginPageObject.Page.Context.Tracing;
        //    await tracing.StopAsync(new TracingStopOptions()
        //    {
        //        Path = $"traces/{_traceName}.zip"
        //    });
        //}

    }
}