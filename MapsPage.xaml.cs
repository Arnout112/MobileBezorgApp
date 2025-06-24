using Map = Microsoft.Maui.Controls.Maps.Map;

namespace MobileBezorgApp;

public partial class MapsPage : ContentPage
{
    public MapsPage()
    {
        InitializeComponent();

        map.IsShowingUser = true;
    }
}