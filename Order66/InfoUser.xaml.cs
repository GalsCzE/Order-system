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
    /// Interakční logika pro InfoUser.xaml
    /// </summary>
    public partial class InfoUser : Page
    {
        int iid;

        public InfoUser(int IDuserss)
        {
            InitializeComponent();
            iid = IDuserss;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new Jidelna());
        }
    }
}
