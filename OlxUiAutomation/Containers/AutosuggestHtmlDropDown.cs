using System;
using System.Collections.Generic;
using System.Linq;
using OlxUiAutomation.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DriverService = OlxUiAutomation.Core.DriverService;

namespace OlxUiAutomation.Containers
{
    public class AutosuggestHtmlDropDown:AbstractPage
    {
        [FindsBy(How = How.Id, Using = "autosuggest-geo-ul")]
        private IWebElement dropDown;

        [FindsBy(How = How.Id, Using = "mapAddress")]
        private IWebElement entry;

        
        protected override AbstractContainer GetConcreteContainer()
        {
            return this;
        }

        public void SelectLocation(string location)
        {
            smartType(location);
            DriverService.Driver.Wait(() => dropDown.Displayed,TimeSpan.FromSeconds(10));
            IList<IWebElement> cities = dropDown.FindElements(By.XPath("./li/a"));

            var element = cities.FirstOrDefault(city => city.Text.StartsWith(location));
            if (element == null)
                throw new ArgumentException("Item not found:" + location);
            element.Click();
        }

        private void smartType(string location)
        {
            entry.Clear();
            foreach (char letter in location)
            {
                entry.SendKeys(letter.ToString());
                DriverService.Driver.WaitForQuery();
 }
        }
    }
}
