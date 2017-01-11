using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlxUiAutomation.Core;
using OlxUiAutomation.Flow;
using OlxUiAutomation.Pages;
using OlxUiAutomation.TestData;

namespace OlxUiAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            /* This small application will login into Olx.UA using test account provided in TestData.cs
             * Please, notice that for this test Olx account, I didn't provide a phone number (which is required for ad publishing), since I've already registered in Olx.
             * Due to Olx restriction, only one account might be linked to one phone number. Since I'm not going to share my real staff on OLX,
             * application wouldn't publish advertisement with given login credentials.
             * You can change login credentials to your own and run it. Hope it will work.
             */

            DriverService.Driver.NativeDriver.Manage().Window.Maximize();
            LoginFlow loginFlow = new LoginFlow();
            loginFlow.Login(TestDataService.TestData.UserName, TestDataService.TestData.Password);
            new HomePage().CreateAdvertisementLink.Click();

            AdvertisementOptions options = new AdvertisementOptions
            {
                Title = "Автоматизированоое тестирование веб ресурсов",
                Description = "Автоматизированоое тестирование веб ресурсов качественно :)",
                Heading = "Работа>ИТ / телеком / компьютеры",
                Location = "Киев",
                Person = "Автотестер"
            };

            //var extendedOptions = new Dictionary<string, string> { { "Предлагаете / ищете?", "Ищу работу" },
            //                                                       { "Тип работы", "Постоянная работа" },
            //                                                       {"Тип занятости","Работа на полную ставку"}};

            var extendedOptions = new Dictionary<string, string> { { "Предлагаете / ищете?", "Предлагаю работу" },
                                                                   { "Тип работы", "Постоянная работа" },
                                                                   {"Тип занятости","Работа на полную ставку"},
                                                                   {"МинЗП","10"},
                                                                   {"МаксЗП","100"}};

            AbstractAdvertisementPage.Create(options,extendedOptions).CreateAd();

            Console.ReadLine();
            DriverService.Driver.NativeDriver.Quit();
        }
    }
}
