using MobileBezorgApp.Helpers;

namespace MobileBezorgApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Eenmalig zetten bij eerste run
            Task.Run(async () =>
            {
                string? apiKey = await SecureStorageHelper.GetApiKeyAsync();

                if (string.IsNullOrEmpty(apiKey))
                {
                    await SecureStorageHelper.SaveApiKeyAsync("4b345b49-cf97-4e16-b2f9-79281a8d2b42");
                }
            });

            MainPage = new NavigationPage(new MainPage());
        }
    }
}