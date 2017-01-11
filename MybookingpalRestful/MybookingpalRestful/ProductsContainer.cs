using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MybookingpalRestful
{
    public class ProductsContainer
    {
        public SearchResponse search_response { set; get; }

        public class SearchResponse
        {
            public bool is_error { get; set; }
            public string message { get; set; }
            public int? messageCode { get; set; }
            public SearchQuotes search_quotes { get; set; }
        }

        public class SearchQuotes
        {
            public int? id { get; set; }
            public int? page_number { get; set; }
            public IList<Quote> quote { get; set; }
            public int? quotes_count { get; set; }
            public int? quotes_per_page { get; set; }
            public string xsl { get; set; }
        }

        public class Quote
        {
            public string address { get; set; }
            public string alert { get; set; }
            public DateTime arrive { get; set; }
            public string attributes { get; set; }
            public int? bar { get; set; }
            public int? bathroom { get; set; }
            public int? bedroom { get; set; }
            public DateTime checkin { get; set; }
            public string CheckInDayRequired { get; set; }
            public DateTime checkout { get; set; }
            public double? cost { get; set; }
            public string currency { get; set; }
            public DateTime depart { get; set; }
            public int? deposit { get; set; }
            public bool exactmatch { get; set; }
            public int? guests { get; set; }
            public bool inquiryOnly { get; set; }
            public string latitude { get; set; }
            public int? locationid { get; set; }
            public string longitude { get; set; }
            public string managerName { get; set; }
            public int? minstay { get; set; }
            public string pictureLocation { get; set; }
            public double? price { get; set; }
            public int productid { get; set; }
            public string productname { get; set; }
            public int? quantity { get; set; }
            public int? quote { get; set; }
            public IList<QuoteDetail> quotedetail { get; set; }
            public double? rack { get; set; }
            public double? sto { get; set; }
            public int? taxrate { get; set; }
            public string xsl { get; set; }
            public string productClassType { get; set; }
        }

        public class QuoteDetail
        {
            public string currency { get; set; }
            public DateTime date { get; set; }
            public int? id { get; set; }
            public int? minimum { get; set; }
            public int? minStay { get; set; }
            public string name { get; set; }
            public int? quantity { get; set; }
            public DateTime todate { get; set; }
            public string type { get; set; }
            public string unit { get; set; }
            public double? value { get; set; }
            public int? rule { get; set; }
        }
    }
}
