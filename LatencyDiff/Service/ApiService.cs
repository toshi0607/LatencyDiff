using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LatencyDiff.Service
{
    public class ApiService
    {
        public static async Task<dynamic> GetTagsAsync(string userName)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(GetUrl(userName));

            string json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject(json);
        }

        private static string GetUrl(string userName)
        {
            return $"http://qiita.com/api/v2/users/{userName}/following_tags";
        }
    }
}
