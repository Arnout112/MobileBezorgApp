using MobileBezorgApp.Helpers;

namespace MobileBezorgApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnApiCallClicked(object sender, EventArgs e)
        {
            string? apiKey = await SecureStorageHelper.GetApiKeyAsync();

            if (string.IsNullOrEmpty(apiKey))
            {
                await DisplayAlert("Fout", "Geen API key gevonden.", "OK");
                return;
            }

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("ApiKey", apiKey);

                var response = await client.GetAsync("http://51.137.100.120:5000/api/DeliveryStates/GetAllDeliveryStates");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Succes", content, "OK");
                }
                else
                {
                    await DisplayAlert("Error", $"Statuscode: {response.StatusCode}", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fout", $"Type: {ex.GetType().Name}\nMessage: {ex.Message}\nStackTrace: {ex.StackTrace}", "OK");
            }
        }

        private async void OnStartScannerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QrScannerPage());
        }
    }

}
