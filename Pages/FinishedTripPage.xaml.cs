namespace MobileBezorgApp;

public partial class FinishedTripPage : ContentPage
{
	public FinishedTripPage()
	{
		InitializeComponent();
	}

	private async void OnLogoutClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new UitloggenPage());
	}

	private async void OnNavigationButtonClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new MapsPage());
    }

}