using System;
using System.Linq;
using OlxUiAutomation.Core;
using OpenQA.Selenium;
using DriverService = OlxUiAutomation.Core.DriverService;

namespace OlxUiAutomation.Containers
{
    public class HtmlDropDown:AbstractContainer
    {
        private readonly IWebElement _rootElement;

        protected override AbstractContainer GetConcreteContainer()
        {
            return this;
        }

        public HtmlDropDown(IWebElement rootElement)
        {
            _rootElement = rootElement;
        }

        public void Select(string item)
        {
            DriverService.Driver.Wait(() =>
            {
                _rootElement.Click();
                var dropDown = _rootElement.FindElement(By.XPath("./dd/ul"));
                DriverService.Driver.Wait(() => dropDown.Displayed, TimeSpan.FromSeconds(5));
                var elements = _rootElement.FindElements(By.XPath("./dd/ul/li/a"));
                elements.FirstOrDefault(el => el.Text == item).Click();
                return true;
            }, TimeSpan.FromSeconds(10));

            DriverService.Driver.WaitForQuery();
        }
    }
}
