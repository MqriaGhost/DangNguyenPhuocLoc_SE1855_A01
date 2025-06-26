using BusinessObjects;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class OrderHistoryViewModel : ViewModelBase
    {
        public Customers CurrentCustomer { get; set; }

        public OrderHistoryViewModel(Customers customer)
        {
            CurrentCustomer = customer;
            // We'll add the logic to load orders here later
        }
    }
}