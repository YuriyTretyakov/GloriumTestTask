namespace OlxUiAutomation.Core
{
    public static class DriverService
    {
        private static Driver _driver;

        public static Driver Driver
        {
            get { return _driver ?? (_driver = new Driver()); }
        }
    }
}
