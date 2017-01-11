using OpenQA.Selenium.Support.PageObjects;

namespace OlxUiAutomation.Core
{
    public abstract class AbstractContainer
    {
        protected AbstractContainer()
        {
            PageFactory.InitElements(DriverService.Driver.NativeDriver, GetConcreteContainer());
        }

        protected abstract AbstractContainer GetConcreteContainer();
    }
}
