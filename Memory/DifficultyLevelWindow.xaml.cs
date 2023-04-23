using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for DifficultyLevelWindow.xaml
    /// </summary>
    public partial class DifficultyLevelWindow : Window
    {
        public DifficultyLevelWindow()
        {
            InitializeComponent();
        }

        private void btn_Easy_Click(object sender, RoutedEventArgs e)
        {
            PlayEasyWindow playEasyWindow = new PlayEasyWindow();
            playEasyWindow.Show();
            this.Close();
        }

        private void tbn_Medium_Click(object sender, RoutedEventArgs e)
        {
            PlayMediumWindow playMediumWindow = new PlayMediumWindow();
            playMediumWindow.Show();
            this.Close();
        }

        private void btn_Hard_Click(object sender, RoutedEventArgs e)
        {
            PlayHardWindow playHardWindow = new PlayHardWindow();
            playHardWindow.Show();
            this.Close();
        }
    }
}
