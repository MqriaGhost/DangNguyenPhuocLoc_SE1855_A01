using System.Windows;

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
            
            DialogResult = true;
        }
    }
}