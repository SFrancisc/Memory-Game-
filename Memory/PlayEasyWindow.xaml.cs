using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Memory
{
    /// <summary>
    /// Interaction logic for PlayEasyWindow.xaml
    /// </summary>
    public partial class PlayEasyWindow : Window
    {
        MemoryCard selectedCard;
        int numberOfSelectedCards;
        DispatcherTimer timer;
        DateTime start = DateTime.Now;
        int numberOfPairs = 10;

        public PlayEasyWindow()
        {
            InitializeComponent();
            InitGameView();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            tbk_Timer.Text = (currentTime - start).ToString();
        }

        private void InitGameView()
        {
            stack_Cards.Children.Clear();
            List<string> cardTypes = new List<string> { "1", "1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7", "8", "8", "9", "9", "10", "10" };


            for (int i = 0; i < 4; i++)
            {
                StackPanel cardRowPanel = new StackPanel();
                cardRowPanel.Orientation = Orientation.Horizontal;

                for (int j = 0; j < 5; j++)
                {
                    Random random = new Random();
                    int index = random.Next(0, cardTypes.Count);
                    string cardType = cardTypes[index];
                    cardTypes.RemoveAt(index);
                    MemoryCard card = new MemoryCard(cardType);
                    card.Margin = new Thickness(20, 0, 0, 0);
                    card.MouseLeftButtonDown += Card_MouseLeftButtonDown;
                    cardRowPanel.Children.Add(card);
                }
                cardRowPanel.Margin = new Thickness(0, 10, 0, 0);
                stack_Cards.Children.Add(cardRowPanel);
            }
        }

        private async void Card_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MemoryCard card = sender as MemoryCard;

            if (numberOfSelectedCards == 0)
            {
                if (!card.IsSelected)
                {
                    card.IsSelected = true;
                    card.ShowMemoryCardFront();
                    selectedCard = card;
                    numberOfSelectedCards++;
                }
            }
            else if (numberOfSelectedCards == 1)
            {
                if (!card.IsSelected)
                {
                    card.IsSelected = true;
                    card.ShowMemoryCardFront();
                    await Task.Delay(500);
                    if (selectedCard.Type == card.Type)
                    {
                        selectedCard.Visibility = Visibility.Hidden;
                        card.Visibility = Visibility.Hidden;
                        numberOfSelectedCards = 0;
                        numberOfPairs--;
                        if (numberOfPairs == 0)
                        {
                            timer.Stop();
                            MessageBox.Show("You finished in " + tbk_Timer.Text);

                        }
                        selectedCard = null;
                    }
                    else
                    {
                        card.ShowMemoryCardBack();
                        selectedCard.ShowMemoryCardBack();
                        numberOfSelectedCards = 0;
                        selectedCard = null;
                    }
                }
            }
        }
    }
}
