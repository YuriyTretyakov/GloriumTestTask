using System.Net.Http;

namespace MybookingpalRestful
{
    public class ContentProvider
    {
        public string GetContent(string url)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage message = client.GetAsync(url).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
