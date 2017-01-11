using OlxUiAutomation.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OlxUiAutomation.Pages
{
    public class HomePage:AbstractPage
    {
        [FindsBy(How = How.Id,Using = "postNewAdLink")]
        public IWebElement CreateAdvertisementLink;

        protected override AbstractContainer GetConcreteContainer()
        {
            return this;
        }
    }
}
