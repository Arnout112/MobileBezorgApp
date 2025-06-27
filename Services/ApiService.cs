using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
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

        private async Task AddApiKeyHeaderAsync()
        {
            var apiKey = await SecureStorageHelper.GetApiKeyAsync();
            Debug.WriteLine("Opgehaalde API key: " + apiKey);

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidOperationException("API key is not set.");

            if (_httpClient.DefaultRequestHeaders.Contains("ApiKey"))
                _httpClient.DefaultRequestHeaders.Remove("ApiKey");

            _httpClient.DefaultRequestHeaders.Add("ApiKey", apiKey);

            foreach (var header in _httpClient.DefaultRequestHeaders)
            {
                Debug.WriteLine($"Header: {header.Key} = {string.Join(", ", header.Value)}");
            }
        }

        public async Task<OrderDto> CreateOrderAsync(object orderData)
        {
            await AddApiKeyHeaderAsync();
            var response = await _httpClient.PostAsJsonAsync("api/orders", orderData);
            response.EnsureSuccessStatusCode();
            var createdOrder = await response.Content.ReadFromJsonAsync<OrderDto>();

            var startDeliveryResponse = await _httpClient.PostAsync($"api/DeliveryStates/StartDelivery?OrderId={createdOrder.Id}", null);
            startDeliveryResponse.EnsureSuccessStatusCode();

            return createdOrder;
        }

        public async Task<OrderDto> GetOrderAsync(int orderId)
        {
            await AddApiKeyHeaderAsync();
            return await _httpClient.GetFromJsonAsync<OrderDto>($"api/orders/{orderId}");
        }

        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            await AddApiKeyHeaderAsync();
            var response = await _httpClient.GetAsync("api/orders");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var orders = JsonSerializer.Deserialize<List<OrderDto>>(json);
                return orders;
            }
            return new List<OrderDto>();
        }

        public async Task<List<int>> GetFirstOrderIdsAsync(int limit = 10)
        {
            await AddApiKeyHeaderAsync();
            var response = await _httpClient.GetAsync($"api/orders/ids?limit={limit}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var orderIds = JsonSerializer.Deserialize<List<int>>(json);
                return orderIds ?? new List<int>();
            }
            return new List<int>();
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            await AddApiKeyHeaderAsync();
            var response = await _httpClient.GetAsync($"api/orders/{orderId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var order = JsonSerializer.Deserialize<OrderDto>(json);
                return order;
            }
            return null;
        }
    }
}
