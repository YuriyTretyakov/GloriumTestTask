using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MybookingpalRestful
{
    public class SearchParams
    {
        public DateTime From;
        public DateTime To;
        public string Currency;
        public int Guests;

        public static SearchParams Create(Table specflowTable)
        {
            var row = specflowTable.Rows.FirstOrDefault();
            SearchParams parameters = new SearchParams();
            parameters.Currency = row["Currency"];
            parameters.From = convertDateTime(row["From"]);
            parameters.To = convertDateTime(row["TO"]);
            parameters.Guests = int.Parse(row["Guests"]);
            return parameters;
        }

        static DateTime convertDateTime(string datetimestr)
        {
            var days=int.Parse(new Regex("current+(.+)").Match(datetimestr).Groups[1].Value);
            return DateTime.Now.AddDays(days);
        }
    }
}
