namespace OlxUiAutomation.Core
{
    public abstract class AbstractPage:AbstractContainer
    {
        protected virtual bool WaitForReady()
        {
            return DriverService.Driver.WaitForDoReadyState();
        }
    }
}
