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

                string ritnummer = RitnummerEntry.Text;

                await Navigation.PushAsync(new TripInformationPage(ritnummer));
            }
        }

        private async void OnStartScannerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QrScannerPage());
        }
    }
}
