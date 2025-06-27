using MobileBezorgApp.Managers;
using MobileBezorgApp.Services;

namespace MobileBezorgApp
{
    public partial class TripInformationPage : ContentPage
    {
        private readonly string ritnummer;

        public TripInformationPage(string ritnummer)
        {
            InitializeComponent();
            this.ritnummer = ritnummer;

            RitnummerLabel.Text = $"Ritnummer: {ritnummer}";
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            var apiService = new ApiService();
            var orderIds = await apiService.GetAllOrderIdsAsync();

            if (orderIds.Count == 0)
            {
                await DisplayAlert("Geen orders", "Er zijn geen orders beschikbaar.", "OK");
                return;
            }

            var orderManager = new OrderManager(orderIds);
            await Navigation.PushAsync(new AddressInformationPage(orderManager));
        }
    }
}
