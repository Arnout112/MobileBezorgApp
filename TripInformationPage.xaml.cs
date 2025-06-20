namespace MobileBezorgApp;

public partial class TripInformationPage : ContentPage
{
	public TripInformationPage()
	{
		InitializeComponent();
    }

    private async void OnNextButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddressInformationPage());
    }
}