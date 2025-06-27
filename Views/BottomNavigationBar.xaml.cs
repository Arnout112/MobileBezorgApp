using MobileBezorgApp.Managers;

namespace MobileBezorgApp.Views;

public partial class BottomNavigationBar : ContentView
{
    public static readonly BindableProperty OrderManagerProperty =
        BindableProperty.Create(
            nameof(OrderManager),
            typeof(OrderManager),
            typeof(BottomNavigationBar),
            null);

    public OrderManager OrderManager
    {
        get => (OrderManager)GetValue(OrderManagerProperty);
        set => SetValue(OrderManagerProperty, value);
    }

    public BottomNavigationBar()
    {
        InitializeComponent();

        var qrTap = new TapGestureRecognizer();
        qrTap.Tapped += OnQrCodeTapped;
        QrButton.GestureRecognizers.Add(qrTap);

        var homeTap = new TapGestureRecognizer();
        homeTap.Tapped += OnHomeButtonTapped;
        HomeButton.GestureRecognizers.Add(homeTap);

        var naviTap = new TapGestureRecognizer();
        naviTap.Tapped += OnNavigationButtonTapped;
        NavigationButton.GestureRecognizers.Add(naviTap);
    }

    private async void OnHomeButtonTapped(object sender, EventArgs e)
    {
        if (OrderManager != null)
            await Navigation.PushAsync(new AddressInformationPage(OrderManager));
        else
            await Application.Current.MainPage.DisplayAlert("Fout", "OrderManager niet beschikbaar!", "OK");
    }

    private async void OnQrCodeTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QrScannerPage());
    }

    private async void OnNavigationButtonTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapsPage());
    }
}

