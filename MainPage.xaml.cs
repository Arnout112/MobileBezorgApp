using Microsoft.Maui.Controls;
using MobileBezorgApp.Helpers;

namespace MobileBezorgApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RitnummerEntry.Text))
            {
                ValidationLabel.Text = "Ritnummer is verplicht.";
                ValidationLabel.IsVisible = true;
            }
            else
            {
                ValidationLabel.IsVisible = false;
                await Navigation.PushAsync(new TripInformationPage());
            }
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
