using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace SimpleWeb.Tests.Steps
{
    [Binding]
    public class PrivacyPageSteps
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void Setup()
        {
            _driver = GlobalDriverSetup.Driver;
        }

        [Given("I open the Privacy page")]
        public void GivenIOpenThePrivacyPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:5252/Home/Privacy");
        }
    }
}
