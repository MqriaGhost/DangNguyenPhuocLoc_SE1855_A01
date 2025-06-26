using BusinessObjects;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        public Customers CurrentCustomer { get; set; }

        public ProfileViewModel(Customers customer)
        {
            CurrentCustomer = customer;
        }
    }
}