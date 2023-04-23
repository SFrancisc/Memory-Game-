using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == string.Empty || txtLastName.Text == string.Empty || txtId.Text == string.Empty || txtPassword.Password == string.Empty
                || txtConfirmPassword.Password == string.Empty || txtEmail.Text == string.Empty)
            {
                MessageBox.Show("All fields are mandatory.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (PlayersManager.CheckPlayerIdExists(txtId.Text))
                {
                    MessageBox.Show("A player with the same ID already exists", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (PlayersManager.CheckPlayerEmailExists(txtEmail.Text))
                {
                    MessageBox.Show("An account for this mail address already exists", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (txtPassword.Password != txtConfirmPassword.Password)
                    {
                        MessageBox.Show("You have to enter the same password", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Player player = new Player(txtName.Text, txtLastName.Text, txtId.Text, txtPassword.Password, txtEmail.Text);
                        PlayersManager.AddPlayerToDatabase(player);
                        var result = MessageBox.Show("Account created succesfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (result == MessageBoxResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
