using System.Windows;
using System.Windows.Controls; // Required for Validation class

namespace DangNguyenPhuocLocWPF.Views
{
    public partial class ProductDialog : Window
    {
        public ProductDialog()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Check each control for validation errors
            if (Validation.GetHasError(CategoryIdTextBox) ||
                Validation.GetHasError(UnitPriceTextBox) ||
                Validation.GetHasError(UnitsInStockTextBox))
            {
                MessageBox.Show("Please fix all validation errors before saving.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Stop the save operation
            }

            // If there are no errors, proceed with closing the dialog
            DialogResult = true;
        }
    }
}