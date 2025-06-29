using MobileBezorgApp.Managers;
using MobileBezorgApp.Models;
using MobileBezorgApp.ViewModels;

namespace MobileBezorgApp
{
    public partial class AddressInformationPage : ContentPage
    {
        private readonly AddressInformationViewModel viewModel = new AddressInformationViewModel();
        private readonly OrderManager orderManager;

        public AddressInformationPage(OrderManager orderManager)
        {
            InitializeComponent();
            this.orderManager = orderManager;
            viewModel.OrderManager = orderManager;
            BindingContext = viewModel;

            var phoneTap = new TapGestureRecognizer();
            phoneTap.Tapped += OnPhoneTapped;
            PhoneImage.GestureRecognizers.Add(phoneTap);

            Loaded += AddressInformationPage_Loaded;
        }

        public void UpdateBezorgadresLabel()
        {
            int current = orderManager.CurrentIndex + 1;
            int total = orderManager.TotalOrdersCount();

            BezorgadresLabel.Text = $"Bezorgadres {current}/{total}";
        }

        private async void AddressInformationPage_Loaded(object sender, EventArgs e)
        {
            await LoadCurrentOrderAsync();
            UpdateBezorgadresLabel();
        }

        private async Task LoadCurrentOrderAsync()
        {
            try
            {
                OrderDto currentOrder = orderManager.GetCurrentOrder();
                await viewModel.LoadData(currentOrder);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fout", $"Kon order niet laden: {ex.Message}", "OK");
            }
        }

        private void OnPhoneTapped(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("06134573");
            }
            catch
            {
                DisplayAlert("Fout", "Bellen is niet mogelijk op dit apparaat.", "OK");
            }
        }

        private async void OnDeliveredButtonClicked(object sender, EventArgs e)
        {
            if (orderManager.HasNextOrder())
            {
                orderManager.MoveToNextOrder();
                await viewModel.LoadData(orderManager.GetCurrentOrder());
                UpdateBezorgadresLabel();
            }
            else
            {
                await Navigation.PushAsync(new FinishedTripPage());
            }
        }
    }

}
