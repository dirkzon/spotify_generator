using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyGenerator.ApiWrapper
{
    public static class ApiContext
    {
        //een get call maken naar de api met een httpclient en een requesturl
        public static async Task<T> Get<T>(HttpClient client, string requesturl)
        {
            using (HttpResponseMessage response = await client.GetAsync(requesturl))
            {
                if (response.IsSuccessStatusCode)
                {
                    var model = await response.Content.ReadAsAsync<T>();
                    return model;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //een post call maken naar de api met een httpclient requesturl en content
        public static async Task<T> Post<T>(HttpClient client, string requesturl, HttpContent content)
        {
            using (HttpResponseMessage response = await client.PostAsync(requesturl, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var model = await response.Content.ReadAsAsync<T>();
                    return model;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
