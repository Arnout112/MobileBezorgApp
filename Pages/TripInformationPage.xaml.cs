using System.Diagnostics;
using MobileBezorgApp.Managers;
using MobileBezorgApp.Models;
using MobileBezorgApp.Services;

namespace MobileBezorgApp
{
    public partial class TripInformationPage : ContentPage
    {
        private readonly string _ritnummer;
        private List<OrderDto> _orders;

        public TripInformationPage(string ritnummer, List<OrderDto> orders)
        {
            InitializeComponent();

            _ritnummer = ritnummer;
            _orders = orders;

            RitnummerLabel.Text = $"Ritnummer: {_ritnummer}";
            AantalAdressenLabel.Text = $"Aantal adressen: {_orders.Count}";
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            var orderManager = new OrderManager(_orders);
            await Navigation.PushAsync(new AddressInformationPage(orderManager));
        }
    }
}
