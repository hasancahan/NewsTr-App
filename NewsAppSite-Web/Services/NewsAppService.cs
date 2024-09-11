using Microsoft.AspNetCore.Http.HttpResults;
using NewsAppSite_Web.Managers;
using NewsAppSite_Web.Models;
using Newtonsoft.Json.Linq;

namespace NewsAppSite_Web.Services
{
    public class NewsAppService : INewsAppManager
    {
        private readonly string apiKey = "e3b1cfbb00d44b54ae236809c2edde89";
        private readonly string apiKeytr = "pub_940c1ec3c1ff1f6c7ff21fb018b1f031137";

        public async Task<List<News>> GetLatestNewsAsync()
        {
            var news = new List<News>();
            using (var client = new HttpClient()) 
            {
                var response = await client.GetStringAsync($"https://newsapi.org/v2/top-headlines?country=us&apiKey={apiKey}");
                var responsetr = await client.GetStringAsync($"https://newsdata.io/api/1/latest?country=tr&apikey={apiKeytr}");

                if (response != null) 
                {
                    var data = JObject.Parse(responsetr);

                    foreach (var item in data["results"])
                    {
                        news.Add(new News
                        {
                            Title = item["title"].ToString(),
                            Description = item["description"].ToString(),
                            Url = item["link"].ToString(),
                            ImageUrl = item["image_url"].ToString(),
                            Content = item["content"].ToString(),
                            PublishedAt = DateTime.Parse(item["pubDate"].ToString())
                        });
                    }
                }
                else {
                }
                

            }

            return news;
        }

        public async Task<List<News>> GetNews()
        {
            var apiKey = "e3b1cfbb00d44b54ae236809c2edde89";
            var apiKeytr = "pub_940c1ec3c1ff1f6c7ff21fb018b1f031137";

            var url = $"https://newsapi.org/v2/top-headlines?country=us&apiKey={apiKey}";
            var urltr = $"https://newsdata.io/api/1/latest?country=tr&apikey={apiKeytr}";

            var news = new List<News>();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

                try
                {

                    var response = await client.GetAsync(urltr);

                    if (!response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error: {response.StatusCode}");
                        Console.WriteLine($"Response: {responseContent}");
                        return news;
                    }

                    var responseString = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(responseString);


                    foreach (var item in data["results"])
                    {
                        // Eğer birden fazla alan boş ise haberi atla
                        if (string.IsNullOrEmpty(item["title"]?.ToString()) ||
                            string.IsNullOrEmpty(item["description"]?.ToString()) ||
                            string.IsNullOrEmpty(item["link"]?.ToString()) ||
                            string.IsNullOrEmpty(item["image_url"]?.ToString()) ||
                            string.IsNullOrEmpty(item["content"]?.ToString()) ||
                            string.IsNullOrEmpty(item["pubDate"]?.ToString()))
                        {
                            continue;
                        }

                        news.Add(new News
                        {
                            Title = item["title"].ToString(),
                            Description = item["description"].ToString(),
                            Url = item["link"].ToString(),
                            ImageUrl = item["image_url"].ToString(),
                            Content = item["content"].ToString(),
                            PublishedAt = DateTime.Parse(item["pubDate"].ToString()),
                        });
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    Console.WriteLine($"Request error: {httpEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General error: {ex.Message}");
                }
            }

            return news;
        }
    }
}
