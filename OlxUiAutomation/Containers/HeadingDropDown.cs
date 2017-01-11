using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OlxUiAutomation.Core;
using OlxUiAutomation.Estensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DriverService = OlxUiAutomation.Core.DriverService;

namespace OlxUiAutomation.Containers
{
    public class CategtoryNotFoundException : ApplicationException
    {
        public CategtoryNotFoundException(string categoryname) : base("Category not found" + categoryname)
        {
        }
    }

    public class HeadingDropDown : AbstractPage
    {
        [FindsBy(How = How.Id, Using = "targetrenderSelect1-0")] private IWebElement rootHeadingControl;

        [FindsBy(How = How.Id, Using = "fancybox-outer")] private IWebElement CategoriesPopup;


        protected override AbstractContainer GetConcreteContainer()
        {
            return this;
        }

        public void SelectHeading(string path)
        {
            string[] items = path.Split('>');
            rootHeadingControl.Click();
            selectMainCategory(items.First());
            selectInnerLevelCategory(items[1]);
        }

        bool waitForCategoriesPopup()
        {
            return WaitForReady() &&
                   DriverService.Driver.Wait(() => CategoriesPopup.Displayed, TimeSpan.FromSeconds(30));
        }

        void selectMainCategory(string mainCategory)
        {
            waitForCategoriesPopup();
            var mainCategoryItems =
                CategoriesPopup.FindElements(By.XPath(".//div[@id='icons-placeholder']/ul[2]/li/div/a"));
            selectCategoryItem(mainCategoryItems, mainCategory);
        }

        void selectInnerLevelCategory(string innercategory)
        {
            var innerCategoryItems =
                CategoriesPopup.FindElements(By.XPath("./div/div/div/div/div[2]//div[@class='overview']/ul/li/a/span[1]"));
            DateTime timeout = DateTime.Now + TimeSpan.FromSeconds(30);

            while (timeout>DateTime.Now)
            {
                try
                {

                    selectCategoryItem(innerCategoryItems, innercategory);
                    return;
                }
                catch (CategtoryNotFoundException)
                {
                    innerCategoryItems.FirstOrDefault(el => el.Text == "").ScrollIntoView();
                }
            }
            throw new CategtoryNotFoundException(innercategory);
        }

        void selectCategoryItem(IList<IWebElement> elements,string category)
        {
            var mainCategoryItem = elements.FirstOrDefault(el => el.Text == category);

            if (mainCategoryItem == null)
                throw new CategtoryNotFoundException(category);

            mainCategoryItem.SafeClick();
            DriverService.Driver.WaitForQuery();
        }

     }
}
