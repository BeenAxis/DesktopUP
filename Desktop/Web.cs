using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace Desktop
{
    public class Web
    {

        public static string Token = ""; //Ну типо тут для авторизации
        
        public static async void QueryGetSync<T>(string url, KeyValuePair<string, string>[] keys, Action<T> act)
        {
            var a = await GetQuery<T>(url);
            Application.Current.Dispatcher.Invoke(
                () =>
                {
                    act.Invoke(a);
                });
        }
        public static async void QueryPostSync(string url, KeyValuePair<string, string>[] keys, Action<string> act)
        {
            var obj = await PostQuery(url, keys);
            Application.Current.Dispatcher.Invoke(
                () =>
                {
                    act.Invoke(obj);
                });
        }

        public static async Task<T> GetQuery<T>(string Url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Token);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync($"https://localhost:5001/api/{Url}");
                if (response.IsSuccessStatusCode)
                {   
                    var json = await response.Content.ReadAsStringAsync();
                    var objectDes = JsonConvert.DeserializeObject<T>(json);
                    return objectDes;
                }
                else
                {
                    MessageBox.Show($"Ошибка при GET запросе в API {response.ReasonPhrase}");
                }
            }
            throw new Exception("Not found!");
        }

        public static async Task<string> PostQuery(string Url, KeyValuePair<string, string>[] keys)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Token);
                
                var url = GenerateUrl(Url, keys);
                var str = new StringContent(url);
                var response = await client.PostAsync(url, str);
                if (response.IsSuccessStatusCode)
                {   
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    MessageBox.Show($"Ошибка при POST запросе в API {response.ReasonPhrase}");
                }
            }
            throw new Exception("Not found!");
        }

        private static string GenerateUrl(string BaseUrlApi, KeyValuePair<string, string>[] keys)
        {
            var bb = "";
            var i = 0;
            foreach (var keyValuePair in keys)
            {
                bb += $"{keyValuePair.Key}={keyValuePair.Value}";
                if (i != keys.Length - 1)
                {
                    bb += "&";
                }
                i++;
            }

            return $"https://localhost:5001/api/{BaseUrlApi}?{bb}";
        }
    }
}