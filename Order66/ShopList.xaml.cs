using System;
using System.Collections.Generic;
using System.Linq;
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
using Order66.Framy;

namespace Order66
{
    /// <summary>
    /// Interakční logika pro ShopList.xaml
    /// </summary>
    public partial class ShopList : Page
    {
        public ShopList()
        {
            InitializeComponent();
        }

        private void shopItem_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new Jidelna());
        }
    
        private void shopInfo_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new InfoUser());
        }

        private void BuyAll_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
