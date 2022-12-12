using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SQLInjection.APIServices
{
    public class ApiHandler:IApiHandler
    {
        private readonly HttpClient _httpClient;

        public ApiHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public T GetAPI<T>(string url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.ContentType = "application/json";
                httpRequest.Method = "GET";
                //httpRequest.Headers.Add("Authorization", "Bearer " + token);
                var response = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var model = JsonConvert.DeserializeObject<T>(result);
                    response.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                string str = "";
                var model = JsonConvert.DeserializeObject<T>(str);
                return model;
            }
        }

    }
}
