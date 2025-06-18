
using Microsoft.Maui.Controls;

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
            await Navigation.PushAsync(new UitloggenPage());

            if (string.IsNullOrWhiteSpace(RitnummerEntry.Text))
            {
                ValidationLabel.Text = "Ritnummer is verplicht.";
                ValidationLabel.IsVisible = true;
            }
            else
            {
                ValidationLabel.IsVisible = false;
            }
        }
    }
}
