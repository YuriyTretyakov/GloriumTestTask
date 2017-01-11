using System;
using System.Collections.Generic;
using OlxUiAutomation.Containers;
using OlxUiAutomation.Core;
using OlxUiAutomation.Estensions;
using OlxUiAutomation.Pages.HeadingSpecific;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DriverService = OlxUiAutomation.Core.DriverService;

namespace OlxUiAutomation.Pages
{
    

    public abstract class AbstractAdvertisementPage:AbstractPage
    {
        private readonly AdvertisementOptions _options;
        private readonly Dictionary<string, string> _optionex;

        [FindsBy(How = How.Id, Using = "add-title")]
        private IWebElement TitleInput;

        [FindsBy(How = How.Id, Using = "add-description")]
        private IWebElement DescriptionInput;

        [FindsBy(How = How.Id, Using = "save")]
        private IWebElement SaveBtn;

        [FindsBy(How = How.Id, Using = "add-person")]
        private IWebElement ContactPerson;
        
        public AutosuggestHtmlDropDown LocationDropDown;

        public HeadingDropDown Heading;

        protected override AbstractContainer GetConcreteContainer()
        {
            return this;
        }

        protected abstract void SetExtendedOption(Dictionary<string, string> optionex);

        protected AbstractAdvertisementPage(AdvertisementOptions options, Dictionary<string, string> optionex)
        {
            _options = options;
            _optionex = optionex;
            LocationDropDown=new AutosuggestHtmlDropDown();
            Heading=new HeadingDropDown();
        }

        public void CreateAd()
        {
            _options.ValidateRequiredFields();
            var confirmPopup = new ConfirmYourAccountPopup();
            confirmPopup.DiscardIfExist();
            Heading.SelectHeading(_options.Heading);
            confirmPopup.DiscardIfExist();
            TitleInput.SendKeys(_options.Title);
            ContactPerson.SetText(_options.Person);
            DescriptionInput.SendKeys(_options.Description);
            LocationDropDown.SelectLocation(_options.Location);
            SetExtendedOption(_optionex);
            DriverService.Driver.WaitForQuery();
            SaveBtn.ScrollIntoView();
            SaveBtn.Click();
            WaitForReady();
        }

        public static AbstractAdvertisementPage Create(AdvertisementOptions options, Dictionary<string, string> optionex)
        {
            if (options.Heading.StartsWith("Работа"))
                    return JobBase.Create(options,optionex);
            throw new NotImplementedException();
            }
        }

    }

