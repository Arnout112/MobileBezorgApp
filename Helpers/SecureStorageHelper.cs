using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBezorgApp.Helpers
{
    public static class SecureStorageHelper
    {
        private const string ApiKeyStorageKey = "ApiKey";

        // Zet de API Key
        public static async Task SaveApiKeyAsync(string apiKey)
        {
            await SecureStorage.SetAsync(ApiKeyStorageKey, apiKey);
        }

        // Haal de API Key op
        public static async Task<string?> GetApiKeyAsync()
        {
            return await SecureStorage.GetAsync(ApiKeyStorageKey);
        }

        // Verwijder indien nodig
        public static async Task RemoveApiKeyAsync()
        {
            SecureStorage.Remove(ApiKeyStorageKey);
        }
    }
}
