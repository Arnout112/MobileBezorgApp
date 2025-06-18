namespace MobileBezorgApp.Helpers
{
    public static class SecureStorageHelper
    {
        private const string ApiKeyStorageKey = "ApiKey";

        public static async Task SaveApiKeyAsync(string apiKey)
        {
            await SecureStorage.SetAsync(ApiKeyStorageKey, apiKey);
        }

        public static async Task<string?> GetApiKeyAsync()
        {
            return await SecureStorage.GetAsync(ApiKeyStorageKey);
        }

        public static Task RemoveApiKeyAsync()
        {
            SecureStorage.Remove(ApiKeyStorageKey);
            return Task.CompletedTask;
        }
    }
}
