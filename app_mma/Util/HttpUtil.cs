using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace app_mma.Util
{
    public abstract class HttpUtil
    {
        public static HttpResponseMessage Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return client.GetAsync(url).Result;
            }
        }

        public static async Task<HttpResponseMessage> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(10);
                return await client.GetAsync(url);
            }
        }
    }
}
