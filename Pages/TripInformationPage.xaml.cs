namespace MobileBezorgApp;

public partial class TripInformationPage : ContentPage
{
    private string _ritnummer;

	public TripInformationPage(string ritnummer)
	{
		InitializeComponent();
        _ritnummer = ritnummer;

        RitnummerLabel.Text = $"Ritnummer: {_ritnummer}";
    }

    private async void OnNextButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddressInformationPage());
    }
}