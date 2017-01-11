using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using DriverService=OlxUiAutomation.Core.DriverService;
namespace OlxUiAutomation.Estensions
{
    public static class ElementExtesnisons
    {
        public static bool Exists(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void SetText(this IWebElement element,string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void SafeClick(this IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch
            {}
        }

        public static void ScrollIntoView(this IWebElement element)
        {
            ((IJavaScriptExecutor)DriverService.Driver.NativeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

      }
}
