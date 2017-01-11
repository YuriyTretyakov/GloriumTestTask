namespace OlxUiAutomation.Core
{
    public static class SettingsService
    {
        private static Settings _settings;

        public static Settings Settings
        {
            get
            {
                if (_settings==null)
                    _settings=new Settings();
                return _settings;
            }
        }
    }
}
