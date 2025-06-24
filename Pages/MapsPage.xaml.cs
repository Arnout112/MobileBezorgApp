using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace MobileBezorgApp;

public partial class MapsPage : ContentPage
{
    public MapsPage()
    {
        InitializeComponent();

        ShowUserLocationOnMap();
    }

    private async void ShowUserLocationOnMap()
    {
        try
        {
            var location = await Geolocation.Default.GetLocationAsync();
            if (location != null)
            {
                var mapSpan = MapSpan.FromCenterAndRadius(
                    new Location(location.Latitude, location.Longitude),
                    Distance.FromKilometers(1));
                map.MoveToRegion(mapSpan);
                map.IsShowingUser = true;
            }
            else
            {
                await DisplayAlert("Error", "Could not get current location.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Location error: {ex.Message}", "OK");
        }
    }
}