using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LatencyDiff.Service
{
    public class FunctionsService
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
            return $"https://qiitaapifunction.azurewebsites.net/api/HttpTriggerCSharp1?code=hvGeYRATF2ULwgOEzWxfPgFr1Qat5RIcVED1RNM1ehPhQ5eUbTt8jA==&name={userName}";
        }
    }
}
