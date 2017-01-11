using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using OlxUiAutomation.Core;
using OlxUiAutomation.Estensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DriverService = OlxUiAutomation.Core.DriverService;

namespace OlxUiAutomation.Pages
{
    public class ConfirmYourAccountPopup : AbstractPage
    {
        [FindsBy(How = How.Id, Using = "fancybox-close")] private IWebElement xButton;
        
        [FindsBy(How = How.Id, Using = "smsVerificationContainer")]
        private IWebElement confirmContainer;

        public bool WasDiscarded { private set; get; }

        protected override bool WaitForReady()
        {
            return DriverService.Driver.WaitForQuery() &&
                   DriverService.Driver.Wait(() => confirmContainer.Displayed && xButton.Displayed,
                       TimeSpan.FromSeconds(10));
        }

        public void DiscardIfExist()
        {
            if (!WaitForReady())
            {
                WasDiscarded = false;
                return;
            }

            try
            {
                xButton.Click();
                DriverService.Driver.WaitForQuery();
                xButton.Click();
            }
            catch(TargetInvocationException)
            {}
            finally 
            {
                WasDiscarded=waitForClose();
            }
        }

        bool waitForClose()
        {
            return DriverService.Driver.WaitForQuery() &&
                DriverService.Driver.Wait(() => !confirmContainer.Exists() && !xButton.Exists(), TimeSpan.FromSeconds(5));
        }

        protected override AbstractContainer GetConcreteContainer()
        {
            return this;
        }
    }
}
