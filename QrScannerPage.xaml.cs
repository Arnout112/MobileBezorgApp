using ZXing.Net.Maui;

namespace MobileBezorgApp;

public partial class QrScannerPage : ContentPage
{
    public QrScannerPage()
    {
        InitializeComponent();
    }

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        cameraBarcodeReaderView.IsDetecting = false;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            var firstResult = e.Results.FirstOrDefault();
            string qrCode = firstResult?.Value ?? "Onbekend";

            if (Uri.TryCreate(qrCode, UriKind.Absolute, out var uriResult))
            {
                await Launcher.OpenAsync(uriResult);
            }
            else
            {
                await DisplayAlert("QR Code", $"Gescand: {qrCode}", "OK");
            }

            await Navigation.PopAsync();
        });
    }

    

    private async void OnNaviCodeTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapsPage());
    }
}
