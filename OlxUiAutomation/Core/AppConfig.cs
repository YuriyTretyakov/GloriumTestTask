using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OlxUiAutomation.Core
{
    public class Settings
    {
        public readonly string Browser;

        public Settings()
        {
            Browser = ConfigurationManager.AppSettings["Browser"];
        }
    }
}
