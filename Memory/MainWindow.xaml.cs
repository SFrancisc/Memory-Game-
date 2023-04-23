using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void link_SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.ShowDialog();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersManager.IsValidLogin(txtID.Text, txtPassword.Password) == false)
            {
                MessageBox.Show("Login failed. Incorrect ID or password", "Login failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                GameMenuWindow gameMenuWindow = new GameMenuWindow(PlayersManager.GetLoggedPalyer(txtID.Text, txtPassword.Password));
                gameMenuWindow.Show();
                this.Close();
            }
        }
    }
}
