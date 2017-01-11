using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OlxUiAutomation.Core;
using OlxUiAutomation.Pages;

namespace OlxUiAutomation.Flow
{
    public class LoginFlow
    {
        public void Login(string username,string password)
        {
            LandingPage page = new LandingPage();
            page.Open();
            page.AccountLink.Click();
            LoginPage loginPage=new LoginPage();
            loginPage.Login(username,password);
        }
    }
}
