using System.Windows;

namespace WPF_App_For_Shop.View
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : System.Windows.Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (username == "admin" && password == "admin")
            {
                new MainWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
