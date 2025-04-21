using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace SimpleWeb.Tests.Steps
{
    [Binding] 
    public class HomePageSteps
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void Setup()
        {
           _driver = GlobalDriverSetup.Driver;
        }

        [Given("I open the home page")]
        public void GivenIOpenTheHomePage()
        {
            _driver.Navigate().GoToUrl("http://localhost:5252");
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string text)
        {
            var pageContent = _driver.PageSource.ToLowerInvariant();
            Assert.IsTrue(pageContent.Contains(text.ToLowerInvariant()), $"Expected to find '{text}' in the page content, but it was not found.");
        }

        [Then(@"I should see delayed text")]
        public void ThenIShouldSeeDelayedText()
        {
            IWebElement revealed = _driver.FindElement(By.Id("delayed"));
            Assert.That(revealed.Text, Is.EqualTo("This response was delayed by 2 seconds."));
        }
    }
}
