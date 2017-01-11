using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OlxUiAutomation.Containers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DriverService=OlxUiAutomation.Core.DriverService;


namespace OlxUiAutomation.Pages.HeadingSpecific
{
    public abstract class JobBase : AbstractAdvertisementPage
    {
        [FindsBy(How = How.Id, Using = "targetid-offer-seek")] public IWebElement JobSearchType;
        [FindsBy(How = How.Id, Using = "targetparam131")] public IWebElement JobType;
        [FindsBy(How = How.Id, Using = "targetparam135")] public IWebElement TypeofBusy;

        public static AbstractAdvertisementPage Create(AdvertisementOptions options,Dictionary<string, string> optionex)
        {
            switch (optionex["Предлагаете / ищете?"])
            {
                case "Ищу работу":
                    return new LookForJob(options, optionex);
                case "Предлагаю работу":
                    return new ProvideJob(options, optionex);
                default:
                    throw new NotImplementedException();
            }
        }

        protected JobBase(AdvertisementOptions options, Dictionary<string, string> optionex) : base(options, optionex)
        {
        }

        protected override void SetExtendedOption(Dictionary<string, string> optionex)
        {
            new HtmlDropDown(JobSearchType).Select(optionex["Предлагаете / ищете?"]);
            new HtmlDropDown(JobType).Select(optionex["Тип работы"]);
            new HtmlDropDown(TypeofBusy).Select(optionex["Тип занятости"]);
        }
    }


    public class LookForJob : JobBase
    {
        public LookForJob(AdvertisementOptions options, Dictionary<string, string> optionex) : base(options, optionex)
        {
        }
    }

    public class ProvideJob : JobBase
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='parameter-div-salary']//input[1]")] public IWebElement SalaryMin;
        [FindsBy(How = How.XPath, Using = "//div[@id='parameter-div-salary']//input[2]")] public IWebElement SalaryMax;
        
        protected override void SetExtendedOption(Dictionary<string, string> optionex)
        {
            base.SetExtendedOption(optionex);
            SalaryMin.SendKeys(optionex["МинЗП"]);
            SalaryMax.SendKeys(optionex["МаксЗП"]);
        }

        public ProvideJob(AdvertisementOptions options, Dictionary<string, string> optionex) : base(options, optionex)
        {
        }
    }

}
