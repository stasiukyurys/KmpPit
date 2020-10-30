using System.Windows;

namespace KmpPit
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ButtonSand_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PagePit());
        }

        private void ButtonAccess_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
