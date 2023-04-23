using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Memory
{
    /// <summary>
    /// Interaction logic for PlayMediumWindow.xaml
    /// </summary>
    public partial class PlayMediumWindow : Window
    {
        MemoryCard selectedCard;
        int number_of_selected_cards;
        DispatcherTimer timer;
        DateTime start = DateTime.Now;
        public PlayMediumWindow()
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
            List<string> cardTypes = new List<string> { "1", "1", "2", "2", "3", "3", "4", "4", "5", "5", "6", "6", "7", "7", "8", "8", "9", "9", "10", "10", "11", "11", "12", "12", "13", "13", "14", "14", "15", "15" };


            for (int i = 0; i < 5; i++)
            {
                StackPanel cardRowPanel = new StackPanel();
                cardRowPanel.Orientation = Orientation.Horizontal;

                for (int j = 0; j < 6; j++)
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

            if (number_of_selected_cards == 0)
            {
                if (!card.IsSelected)
                {
                    card.IsSelected = true;
                    card.ShowMemoryCardFront();
                    selectedCard = card;
                    number_of_selected_cards++;
                }
            }
            else if (number_of_selected_cards == 1)
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
                        number_of_selected_cards = 0;
                        selectedCard = null;
                    }
                    else
                    {
                        card.ShowMemoryCardBack();
                        selectedCard.ShowMemoryCardBack();
                        number_of_selected_cards = 0;
                        selectedCard = null;
                    }
                }
            }
        }
    }
}
