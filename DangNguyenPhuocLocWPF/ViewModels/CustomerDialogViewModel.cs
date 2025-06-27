using BusinessObjects;

namespace DangNguyenPhuocLocWPF.ViewModels
{
    public class CustomerDialogViewModel : ViewModelBase
    {
        private Customers _customer;

        public Customers Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
        public bool IsEditMode { get; }

        public CustomerDialogViewModel(Customers customer)
        {
            // We create a copy so changes are not saved unless the user clicks "Save"
            Customer = new Customers
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                Phone = customer.Phone
            };
            IsEditMode = (customer.CustomerId != 0);
        }
    }
}