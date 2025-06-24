namespace MobileBezorgApp.Views;

public partial class BottomNavigationBar : ContentView
{
    public BottomNavigationBar()
    {
        InitializeComponent();

        // QR tap gesture
        var qrTap = new TapGestureRecognizer();
        qrTap.Tapped += OnQrCodeTapped;
        QrButton.GestureRecognizers.Add(qrTap);

        // DeliverImage tap gesture
        var homeTap = new TapGestureRecognizer();
        homeTap.Tapped += OnHomeButtonTapped;
        HomeButton.GestureRecognizers.Add(homeTap);

        // Navigation tap gesture
        var naviTap = new TapGestureRecognizer();
        naviTap.Tapped += OnNavigationButtonTapped;
        NavigationButton.GestureRecognizers.Add(naviTap);
    }

    private async void OnQrCodeTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QrScannerPage());
    }

    private async void OnNavigationButtonTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapsPage());
    }

    private async void OnHomeButtonTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddressInformationPage());
    }
}

// Helper extension to find the parent page
public static class VisualElementExtensions
{
    public static Page? GetParentPage(this VisualElement element)
    {
        Element? parent = element.Parent;
        while (parent != null && parent is not Page)
            parent = parent.Parent;
        return parent as Page;
    }
}