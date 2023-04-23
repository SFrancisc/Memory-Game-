using System.Windows.Controls;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MemoryCard.xaml
    /// </summary>
    public partial class MemoryCard : UserControl
    {
        public bool IsSelected { get; set; } = false;
        public string Type { get; set; }
        public MemoryCard(string type)
        {
            InitializeComponent();
            Type = type;
            ShowMemoryCardBack();
        }

        public void ShowMemoryCardBack()
        {
            frame_MemoryCard.Content = new MemoryCardBack();
            IsSelected = false;
        }

        public void ShowMemoryCardFront()
        {
            frame_MemoryCard.Content = new MemoryCardFront(Type);
            IsSelected = true;
        }

    }
}
