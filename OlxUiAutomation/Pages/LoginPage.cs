using System;
using OlxUiAutomation.Core;
using OlxUiAutomation.Estensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DriverService = OlxUiAutomation.Core.DriverService;

namespace OlxUiAutomation.Pages
{
    public class LoginPage:AbstractPage
    {

        [FindsBy(How = How.ClassName, Using = "login-box")]
        public IWebElement LoginPopup;

        [FindsBy(How = How.Id, Using = "userEmail")]
        public IWebElement Email;

        [FindsBy(How = How.Id, Using = "userPass")]
        public IWebElement Password;

        [FindsBy(How = How.Id, Using = "se_userLogin")]
        public IWebElement LoginButton;

        
        public void Login(string username,string password)
        {
            WaitForReady();
            Email.SendKeys(username);
            Password.SendKeys(password);
            LoginButton.Click();
            waitForClose();
        }

        protected override bool WaitForReady()
        {
            return base.WaitForReady()&&
                DriverService.Driver.Wait(() => LoginPopup.Displayed && Email.Displayed && Password.Displayed, TimeSpan.FromSeconds(30));
        }

        protected override AbstractContainer GetConcreteContainer()
        {
            return this;
        }

        bool waitForClose()
        {
            return base.WaitForReady()&&
            DriverService.Driver.Wait(() => !LoginPopup.Exists() && !Email.Exists() && !Password.Exists(), TimeSpan.FromSeconds(30));
        }
    }
}
