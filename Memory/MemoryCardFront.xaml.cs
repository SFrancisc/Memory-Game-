using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MemoryCardFront.xaml
    /// </summary>
    public partial class MemoryCardFront : UserControl
    {
        public MemoryCardFront(string type)
        {
            InitializeComponent();
            BitmapImage cardImage = new BitmapImage();
            cardImage.BeginInit();
            cardImage.UriSource = new Uri("pack://application:,,,/images/" + type + ".jpg");
            cardImage.EndInit();
            img_CardImage.Source = cardImage;
        }
    }
}
