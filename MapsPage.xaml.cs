using Map = Microsoft.Maui.Controls.Maps.Map;

namespace MobileBezorgApp;

public partial class MapsPage : ContentPage
{
    public MapsPage()
    {
        Map map = new Map 
        {
            IsShowingUser = true
        };
        Content = map;
    }
}