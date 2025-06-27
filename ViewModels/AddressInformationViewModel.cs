using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MobileBezorgApp.Services;

namespace MobileBezorgApp.ViewModels
{
    public class AddressInformationViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService = new ApiService();

        private string address;
        public string Address
        {
            get => address;
            set { address = value; OnPropertyChanged(); }
        }

        private string name;
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        private string contact;
        public string Contact
        {
            get => contact;
            set { contact = value; OnPropertyChanged(); }
        }

        private int packageCount;
        public int PackageCount
        {
            get => packageCount;
            set { packageCount = value; OnPropertyChanged(); }
        }

        private string instructions;
        public string Instructions
        {
            get => instructions;
            set { instructions = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public async Task LoadData(int orderId)
        {
            var order = await _apiService.GetOrderAsync(orderId);
            Address = order.Customer.Address;
            Name = order.Customer.Name;
            Contact = "06-134573";
            PackageCount = order.Products.Count;
            Instructions = "3e Etage, geen lift";
        }
    }

}
