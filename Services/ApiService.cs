using System.Net.Http.Json;
using MobileBezorgApp.Helpers;
using MobileBezorgApp.Models;

namespace MobileBezorgApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://51.137.100.120:5000/")
            };
        }

        // Deze private helper gebruiken we altijd
        private async Task AddApiKeyHeaderAsync()
        {
            var apiKey = await SecureStorageHelper.GetApiKeyAsync();

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidOperationException("API key is not set.");

            if (_httpClient.DefaultRequestHeaders.Contains("ApiKey"))
                _httpClient.DefaultRequestHeaders.Remove("ApiKey");

            _httpClient.DefaultRequestHeaders.Add("ApiKey", apiKey);
        }

        public async Task<OrderDto> GetOrderAsync(int orderId)
        {
            await AddApiKeyHeaderAsync();
            return await _httpClient.GetFromJsonAsync<OrderDto>($"api/Order/{orderId}");
        }

        public async Task<List<int>> GetAllOrderIdsAsync()
        {
            await AddApiKeyHeaderAsync();
            var orders = await _httpClient.GetFromJsonAsync<List<OrderDto>>("api/Order");
            return orders.Select(o => o.Id).ToList();
        }
    }
}
