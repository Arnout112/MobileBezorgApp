using Microsoft.Maui.Controls;

namespace MobileBezorgApp;

public partial class UitloggenPage : ContentPage
{
    public UitloggenPage()
    {
        InitializeComponent();
    }

    private async void OnAnnuleerClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnUitloggenClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}


