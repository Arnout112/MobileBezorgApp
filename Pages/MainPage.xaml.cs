using System.Diagnostics;
using Microsoft.Maui.Controls;
using MobileBezorgApp.Helpers;
using MobileBezorgApp.Models;
using MobileBezorgApp.Services;

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
                return;
            }

            ValidationLabel.IsVisible = false;

            string apiKey = "4b345b49-cf97-4e16-b2f9-79281a8d2b42";
            await SecureStorageHelper.SaveApiKeyAsync(apiKey);
            Debug.WriteLine("API key opgeslagen in SecureStorage.");

            string ritnummer = RitnummerEntry.Text;

            var apiService = new ApiService();

            try
            {
                var orderIds = await apiService.GetFirstOrderIdsAsync(10);
                Debug.WriteLine($"Aantal orderIds: {orderIds.Count}");
                foreach (var id in orderIds)
                {
                    Debug.WriteLine($"OrderId: {id}");
                }


                var orders = new List<OrderDto>();

                foreach (var id in orderIds)
                {
                    var order = await apiService.GetOrderByIdAsync(id);
                    if (order != null)
                        orders.Add(order);
                }
                Debug.WriteLine($"Aantal opgehaalde orders: {orders.Count}");

                await Navigation.PushAsync(new TripInformationPage(ritnummer, orders));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Fout bij ophalen orders: {ex.Message}");
                await DisplayAlert("Fout", "Kon orders niet laden.", "OK");
            }
        }

        private async void OnStartScannerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QrScannerPage());
        }
    }
}
