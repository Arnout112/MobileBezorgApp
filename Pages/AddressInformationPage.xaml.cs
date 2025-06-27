using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MobileBezorgApp.Managers;
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
            BindingContext = viewModel;
            this.orderManager = orderManager;

            var phoneTap = new TapGestureRecognizer();
            phoneTap.Tapped += OnPhoneTapped;
            PhoneImage.GestureRecognizers.Add(phoneTap);

            Loaded += AddressInformationPage_Loaded;
        }

        private async void AddressInformationPage_Loaded(object sender, EventArgs e)
        {
            await LoadCurrentOrder();
        }

        private async Task LoadCurrentOrder()
        {
            int currentOrderId = orderManager.GetCurrentOrderId();
            await viewModel.LoadData(currentOrderId);
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
                await LoadCurrentOrder();
            }
            else
            {
                await Navigation.PushAsync(new FinishedTripPage());
            }
        }
    }

}
