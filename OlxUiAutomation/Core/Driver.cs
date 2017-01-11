using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace OlxUiAutomation.Core
{
    public class Driver
    {
        public readonly IWebDriver NativeDriver;
        private const int PollingIntervalSeconds = 5;

        public Driver()
        {
            Type type = DriverBuilder.GetDriverType(SettingsService.Settings.Browser);
            NativeDriver = DriverBuilder.Build(type);
        }

        public bool WaitForQuery(int seconds = 30)
        {
            var wait = new WebDriverWait(NativeDriver, TimeSpan.FromSeconds(seconds));
            wait.PollingInterval = TimeSpan.FromSeconds(PollingIntervalSeconds);
            return
                wait.Until(d =>d.ExecuteJavaScript<Int64>("return jQuery != null && jQuery != undefined && jQuery.active") ==0);
        }

        public bool WaitForDoReadyState(int seconds = 30)
        {
            var wait = new WebDriverWait(NativeDriver, TimeSpan.FromSeconds(seconds));
            wait.PollingInterval = TimeSpan.FromSeconds(PollingIntervalSeconds);
            return wait.Until(drv => drv.ExecuteJavaScript<string>("return document.readyState") == "complete");

        }

        public bool Wait(Func<bool> func, TimeSpan timeout)
        {
            bool result = false;
            DateTime endTime=DateTime.Now+timeout;

            while (!result && endTime>DateTime.Now)
            {
                try
                {
                    result = func.Invoke();
                    if (result)
                        return true;
                    Thread.Sleep(TimeSpan.FromSeconds(PollingIntervalSeconds));
                }
                catch
                {
                    result = false;
                }
            }
            return false;
        }

        
    }
}
