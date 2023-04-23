using System.Windows;

namespace Memory
{
    /// <summary>
    /// Interaction logic for HighScoreWindow.xaml
    /// </summary>
    public partial class HighScoreWindow : Window
    {
        Player loggedPlayer;
        public HighScoreWindow(Player loggedPlayer)
        {
            InitializeComponent();
            this.loggedPlayer = loggedPlayer;
            InitRankingList();
        }

        private void InitRankingList()
        {
            lstRanking.Items.Clear();
            System.Collections.Generic.List<Player> list = PlayersManager.GetPlayers();
            lstRanking.ItemsSource = list;

        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            GameMenuWindow gameMenuWindow = new GameMenuWindow(loggedPlayer);
            gameMenuWindow.Show();
            this.Close();
        }
    }
}
