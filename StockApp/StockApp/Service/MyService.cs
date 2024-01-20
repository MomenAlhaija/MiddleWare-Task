using System;
using System.Text.Json;
namespace StockApp.Service
{
    public class MyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MyService(IHttpClientFactory httpClientFactory){
            _httpClientFactory = httpClientFactory;
        }
        public async Task method()
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://finnhub.io/api/v1/quote?symbol=MSFT&token=cigvbo9r01ql04e4kh50cigvbo9r01ql04e4kh5g")
                    ,
                    Method = HttpMethod.Get
                };
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
               Stream stream= httpResponseMessage.Content.ReadAsStream();
               StreamReader reader = new StreamReader(stream);
               string response= reader.ReadToEnd();
             
            }
            
        }
    }
}
