using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BsEf.Common
{
    public class HttpClientUtil
    {
        //public static string ZosUrl = "http://zos.storageapi.local/api/";
        //public static string SmartShelfUrl = "http://127.0.0.1:8081/api/";
        public static string ApiUrl = "http://localhost:63964/api/";
        //public static string SmartShelfUrl = "http://localhost:10403/api/";
        //public static string SmartShelfUrl = "http://smartshelf.api.local/api/";
        //public static string SmartShelfUrl = "http://smartshelf.api.local:8091/api/";

        /// <summary>  
        /// post请求  
        /// </summary>  
        /// <param name="url"></param>  
        /// <param name="postData">post数据</param>  
        /// <returns></returns>  
        public static string PostResponse(string url, object postData)
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(postData);
            var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        /// <summary>  
        /// post请求(有返回值)  
        /// </summary>  
        /// <param name="url"></param>  
        /// <param name="postData">post数据</param>  
        /// <returns></returns>  
        public static T PostResponse<T>(string url, object postData) where T : class, new()
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(postData);
            var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, httpContent).Result;
            T result = default(T);
            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;
                result = JsonConvert.DeserializeObject<T>(s);
            }
            return result;
        }

        /// <summary>  
        /// put请求  
        /// </summary>  
        /// <param name="url"></param>  
        /// <param name="putData">put数据</param>  
        /// <returns></returns>  
        public static string PutResponse(string url, object putData)
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(putData);
            var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync(url, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        /// <summary>  
        /// delete请求  
        /// </summary>  
        /// <param name="url"></param> 
        /// <returns></returns>  
        public static string DeleteResponse(string url)
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            var response = httpClient.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        /// <summary>  
        /// get请求  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns></returns>  
        public static T GetResponse<T>(string url) where T : class, new()
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            T result = default(T);
            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;
                result = JsonConvert.DeserializeObject<T>(s);
            }
            return result;
        }

        /// <summary>  
        /// get请求返回List集合  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns>List集合</returns>  
        public static List<T> GetAllResponseList<T>(string url) where T : class, new()
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            List<T> result = default(List<T>);
            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;
                if (s != null && !s.StartsWith("["))
                {
                    s = "[" + s + "]";
                }
                result = JsonConvert.DeserializeObject<List<T>>(s);
            }
            return result;
        }

        /// <summary>  
        /// post请求进行分页查询  
        /// </summary>  
        /// <param name="url"></param>  
        /// <param name="postData">查询条件</param>  
        /// <returns>List集合</returns>  
        public static List<T> PaginationResponse<T>(string url, object postData) where T : class, new()
        {
            if (url.StartsWith("https"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(postData);
            var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, httpContent).Result;
            List<T> result = default(List<T>);
            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;
                if (s != null && !s.StartsWith("["))
                {
                    s = "[" + s + "]";
                }
                result = JsonConvert.DeserializeObject<List<T>>(s);
            }
            return result;
        }
    }
}
