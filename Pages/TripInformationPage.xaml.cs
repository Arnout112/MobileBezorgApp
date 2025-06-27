using System.Diagnostics;
using MobileBezorgApp.Managers;
using MobileBezorgApp.Models;
using MobileBezorgApp.Services;

namespace MobileBezorgApp
{
    public partial class TripInformationPage : ContentPage
    {
        private readonly string _ritnummer;
        private List<OrderDto> _orders = new();

        public TripInformationPage(string ritnummer, List<OrderDto> orders)
        {
            InitializeComponent();

            _ritnummer = ritnummer;
            _orders = orders;

            Debug.WriteLine($"TripInformationPage ontvangt orders: {_orders.Count}");

            RitnummerLabel.Text = $"Ritnummer: {_ritnummer}";
            AantalAdressenLabel.Text = $"Aantal adressen: {_orders.Count}";
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            if (_orders == null || _orders.Count == 0)
            {
                await DisplayAlert("Info", "Geen orders gevonden om te tonen.", "OK");
                return;
            }

            var orderManager = new OrderManager(_orders);
            await Navigation.PushAsync(new AddressInformationPage(orderManager));
        }
    }
}
