using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CRUDOperationWebAPI.Helper
{
    public class APIService
    {
        public static readonly string apiBase = ConfigurationManager.AppSettings["apiBasePath"];
        public static async Task<T> Post<T>(string url, T contentValue)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBase);
                client.Timeout = TimeSpan.FromMinutes(10);
                StringContent content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PostAsync(url, content);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                return resultContent;
            }
        }
        public static async Task<T> Put<T>(string url, T contentValue)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBase);
                client.Timeout = TimeSpan.FromMinutes(10);
                StringContent content = new StringContent(JsonConvert.SerializeObject(contentValue), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync(url, content);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                return resultContent;
            }
        }

        public static async Task<T> Get<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBase);
                client.Timeout = TimeSpan.FromMinutes(10);
                HttpResponseMessage result = await client.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                return resultContent;
            }
        }

        public static async Task<T> Delete<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBase);
                client.Timeout = TimeSpan.FromMinutes(10);
                HttpResponseMessage result = await client.DeleteAsync(url);
                result.EnsureSuccessStatusCode();
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                return resultContent;
            }
        }
    }
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }
}