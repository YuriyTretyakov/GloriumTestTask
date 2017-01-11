using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlxUiAutomation.TestData
{
    public static class TestDataService
    {
        private static ITestData _testData;

        public static ITestData TestData
        {
            get
            {
                if (_testData==null)
                    _testData=new TestData();
                return _testData;
            }
        }

    }
}
