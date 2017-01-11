using OlxUiAutomation.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DriverService = OlxUiAutomation.Core.DriverService;

namespace OlxUiAutomation.Pages
{
    public class LandingPage:AbstractPage
    {
        private const string URL = "https://www.olx.ua/";

        [FindsBy(How = How.Id, Using = "topLoginLink")]
        public IWebElement AccountLink;

        public void Open()
        {
            DriverService.Driver.NativeDriver.Navigate().GoToUrl(URL);
            WaitForReady();
        }

        protected override AbstractContainer GetConcreteContainer()
        {
            return this;
        }
    }
}
