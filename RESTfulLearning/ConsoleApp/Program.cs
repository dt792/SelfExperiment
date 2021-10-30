using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        static string hostUrl = "https://localhost:44349/api/cats";
        static void Main(string[] args)
        {
            var c = GetCatByIndex(0);
            c.Wait();
            Console.WriteLine(c.Result);//获取老猫
            var cat = new Cat() { Discription = "参数传过去的" };
            UploadCat(cat);
            UploadCat(cat);
            Thread.Sleep(1000);
            UpdateCat(1, new Cat() { Discription = "改掉的猫猫" });

            FreeCat(0);//放生老猫
            var cats = GetAllCats();
            cats.Wait();
            Console.WriteLine("所有猫猫：");
            foreach (var item in cats.Result)
            {
                Console.WriteLine(item);
            }
        }
        public async static Task<List<Cat>> GetAllCats()
        {
            string url = $"{hostUrl}";
            List<Cat> cats = new List<Cat>();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    HttpContent httpContent = response.Content;
                    string content = await httpContent.ReadAsStringAsync();
                    cats = JsonConvert.DeserializeObject<List<Cat>>(content);
                }
            }
            return cats;
        }
        public async static Task<Cat> GetCatByIndex(int id)
        {
            string url = $"{hostUrl}/{id}";
            Cat cat;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    HttpContent httpContent = response.Content;
                    string content = await httpContent.ReadAsStringAsync();
                    cat = JsonConvert.DeserializeObject<Cat>(content);
                }
            }
            return cat;
        }
        public async static void UploadCat(Cat cat)
        {
            string url = $"{hostUrl}";
            HttpContent content = new StringContent(JsonConvert.SerializeObject(cat));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/josn");
                using (HttpResponseMessage response = await client.PostAsync(url, content))
                {
                    HttpContent httpContent = response.Content;
                }
            }
        }
        public async static void UpdateCat(int id,Cat cat)
        {
            string url = $"{hostUrl}/{id}";
            HttpContent content = new StringContent(JsonConvert.SerializeObject(cat));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/josn");
                using (HttpResponseMessage response = await client.PutAsync(url, content))
                {
                    HttpContent httpContent = response.Content;
                }
            }
        }
        /// <summary>
        /// 放生猫猫
        /// </summary>
        /// <param name="url"></param>
        public async static void FreeCat(int id)
        {
            string url = $"{hostUrl}/{id}";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/josn");
                using (HttpResponseMessage response = await client.DeleteAsync(url))
                {
                    HttpContent httpContent = response.Content;
                }
            }
        }
    }
}
