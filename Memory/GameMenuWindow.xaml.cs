using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for GameMenuWindow.xaml
    /// </summary>
    public partial class GameMenuWindow : Window
    {
        Player loggedPlayer;
        public GameMenuWindow(Player loggedPlayer)
        {
            InitializeComponent();
            this.loggedPlayer = loggedPlayer;
            tbkLoggedPlayerId.Text = "Welcome, " + loggedPlayer.Id;
        }

        private void link_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            DifficultyLevelWindow difficultyLevelWindow = new DifficultyLevelWindow();
            difficultyLevelWindow.Show();
            this.Close();
        }

        private void btnHightScores_Click(object sender, RoutedEventArgs e)
        {
            HighScoreWindow highScoreWindow = new HighScoreWindow(loggedPlayer);
            highScoreWindow.Show();
            this.Close();
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
