namespace MobileBezorgApp
{
    public partial class AddressInformationPage : ContentPage
    {
        public AddressInformationPage()
        {
            InitializeComponent();

            // Phone tap gesture
            var phoneTap = new TapGestureRecognizer();
            phoneTap.Tapped += OnPhoneTapped;
            PhoneImage.GestureRecognizers.Add(phoneTap);
        }

        private void OnPhoneTapped(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("06134573");
            }
            catch (Exception ex)
            {
                DisplayAlert("Fout", "Bellen is niet mogelijk op dit apparaat.", "OK");
            }
        }

        private async void OnDeliveredButtonClicked(object sender, EventArgs e)
        { 
            await Navigation.PushAsync(new FinishedTripPage());
        }

    }
}
