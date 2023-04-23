using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        public EditProfile()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            /* if (txtNewName.Text == string.name)
             {

             }else
                 if(txtNewLastName.Text == string.lastName)
             {

             }else
                 if(txtNewId.Text == string.id)
             {

             }else
                 if(txtNewPassword.Text == string.password)
             {

             }else
                 if(txtConfirmNewPassword.Text != txtNewPassword)
             {

             }
            */
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
