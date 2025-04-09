using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SimpleWeb.Tests
{
    [TestFixture]
    public class HomePageTests : IDisposable
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Run in headless mode (no UI)
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            _driver = new ChromeDriver(options);
        }

        [Test]
        public void HomePage_ShouldContainWelcomeText()
        {
            _driver.Navigate().GoToUrl("http://localhost:5252"); // or your running URL

            string pageSource = _driver.PageSource;
            Assert.IsTrue(pageSource.Contains("Welcome"), "Home page should contain 'Welcome'");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}
