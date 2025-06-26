using System.Windows;
using DangNguyenPhuocLocWPF.Views;

namespace DangNguyenPhuocLocWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}