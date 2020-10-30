using System.Windows;
using System.Windows.Controls;

namespace KmpPit
{
    public partial class PagePit : Page
    {
        public PagePit()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(null);
        }
    }
}
