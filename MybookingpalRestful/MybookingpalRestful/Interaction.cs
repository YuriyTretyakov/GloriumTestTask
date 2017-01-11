using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace MybookingpalRestful
{
   public class Interaction
   {
       private const string SEARCH_PRODUCTS_BASEURL = "https://www.mybookingpal.com/xml/services/json/reservation/products/21980";
       private const string PRODUCT_DETAILS_BASEURL ="https://www.mybookingpal.com/xml/services/json/reservation/quotes";
       private const string POS = "a502d2c65c2f75d3";

       public ProductsContainer GetProductsByCriteria(SearchParams searchParams)
        {
            NameValueCollection paramsCollection = new NameValueCollection
            {
                {"pos",POS},
                {"guests", searchParams.Guests.ToString()},
                {"currency", searchParams.Currency}
            };

            string baseurl = SEARCH_PRODUCTS_BASEURL + string.Format("/{0}/{1}", formatDate(searchParams.From), formatDate(searchParams.To));
            string url = getUrlByParams(paramsCollection, baseurl);
            string content = new ContentProvider().GetContent(url);
            return Deserializer.GetDeserializedObject<ProductsContainer>(content);
        }

       public ProductDetailsContainer GetProductDetails(int productid, SearchParams searchParams)
       {
           NameValueCollection paramsCollection = new NameValueCollection
            {
                {"pos", POS},
                {"productid", productid.ToString()},
                {"fromdate", formatDate(searchParams.From)},
                {"todate",formatDate(searchParams.To)},
                {"currency",searchParams.Currency},
                {"adults",searchParams.Guests.ToString()}
            };

           string url = getUrlByParams(paramsCollection, PRODUCT_DETAILS_BASEURL);
           string content = new ContentProvider().GetContent(url);
           return Deserializer.GetDeserializedObject<ProductDetailsContainer>(content);
       }

       string getUrlByParams(NameValueCollection collection,string baseurl)
       {
           var builder = new UriBuilder(baseurl);
           builder.Query = toQueryString(collection);
           return builder.Uri.AbsoluteUri;
       }

       string toQueryString(NameValueCollection nvc)
       {
           var array = (from key in nvc.AllKeys
                        from value in nvc.GetValues(key)
                        select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
               .ToArray();
           return string.Join("&", array);
       }

       string formatDate(DateTime dateTime)
       {
           return dateTime.ToString("yyyy-MM-dd");
       }
    }
}
