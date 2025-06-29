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
            }
            else
            {
                ValidationLabel.IsVisible = false;

                string apiKey = "4b345b49-cf97-4e16-b2f9-79281a8d2b42";
                await SecureStorageHelper.SaveApiKeyAsync(apiKey);
                Debug.WriteLine("API key opgeslagen in SecureStorage.");

                string ritnummer = RitnummerEntry.Text;

                var apiService = new ApiService();

                var testOrder1 = new CreateOrderDto
                {
                    Customer = new CustomerDto { Name = "Jan Jansen", Address = "Teststraat 1, 1234 AB Amsterdam" },
                    Products = new List<ProductDto> { new ProductDto { Id = 1 }, new ProductDto { Id = 2 } }
                };

                var testOrder2 = new CreateOrderDto
                {
                    Customer = new CustomerDto { Name = "Lisa de Vries", Address = "Leliestraat 5, 5678 CD Utrecht" },
                    Products = new List<ProductDto> { new ProductDto { Id = 3 } }
                };

                var createdOrder1 = await apiService.CreateOrderAsync(testOrder1);
                createdOrder1.Customer = testOrder1.Customer;

                var createdOrder2 = await apiService.CreateOrderAsync(testOrder2);
                createdOrder2.Customer = testOrder2.Customer;

                var orders = new List<OrderDto> { createdOrder1, createdOrder2 };

                await Navigation.PushAsync(new TripInformationPage(ritnummer, orders));
            }
        }



        private async void OnStartScannerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QrScannerPage());
        }
    }
}
