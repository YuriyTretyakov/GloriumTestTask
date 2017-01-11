using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace OlxUiAutomation.Core
{
    public class DriverBuilder
    {
        public static Type GetDriverType(string browser)
        {
            switch (browser)
            {
                case "IE":
                    return typeof(InternetExplorerDriver);
                case "CHROME":
                    return typeof(ChromeDriver);
                default:
                    throw new NotImplementedException();
            }
        }

        public static IWebDriver Build(Type type)
        {
            if (type == typeof(InternetExplorerDriver))
            {
                InternetExplorerOptions options = new InternetExplorerOptions
                {
                    EnableNativeEvents = true,
                    RequireWindowFocus = true,
                    IgnoreZoomLevel = true,
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    EnsureCleanSession = true
                };
                return new InternetExplorerDriver(options);
            }
            if (type == typeof(ChromeDriver))
            {
                ChromeOptions options = new ChromeOptions();
                return new ChromeDriver(options);
            }
            throw new NotImplementedException();
        }

    }
}

