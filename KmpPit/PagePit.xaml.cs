using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KmpPit
{
    /// <summary>
    /// Логика взаимодействия для PagePit.xaml
    /// </summary>
    public partial class PagePit : Page
    {
        public PagePit()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            // NavigationService.Navigate(null);
            this.NavigationService.Navigate(null);
        }
    }
}
