using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace SimpleWeb.Tests.Steps
{
    [Binding]
    public class HomePageSteps : IDisposable
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Run in headless mode (no UI)
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }

        [AfterScenario]
        public void Teardown()
        {
            _driver.Quit();
        }

        [Given("I open the home page")]
        public void GivenIOpenTheHomePage()
        {
            _driver.Navigate().GoToUrl("http://localhost:5252");
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string text)
        {
            Assert.IsTrue(_driver.PageSource.Contains(text));
        }

        [Then(@"I should see delayed text")]
        public void ThenIShouldSeeDelayedText()
        {
            IWebElement revealed = _driver.FindElement(By.Id("delayed"));
            Assert.That(revealed.Text, Is.EqualTo("This response was delayed by 2 seconds."));
        }
    }
}
