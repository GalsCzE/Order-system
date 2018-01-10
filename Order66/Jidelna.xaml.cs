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
using RestSharp;
using System.Net;
using Order66.Interface;
using Order66.JsonParsee;
using Order66.Entity;

namespace Order66
{
    /// <summary>
    /// Interakční logika pro Jidelna.xaml
    /// </summary>
    public partial class Jidelna : Page
    {
        public Jidelna()
        {
            InitializeComponent();
            SHOW();
        }

        public async Task SHOW()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/4ITB/Order-system/Item/dotaz.php");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            // if (response.ResponseStatus == RestSharp.ResponseStatus.Completed) {
            HttpStatusCode stat = response.StatusCode;
            if (stat == HttpStatusCode.OK)
            {
                IParse parser = new JsonParser();
                Produkt_list.ItemsSource = await parser.ParseString<List<Food>>(response.Content);
            }
            else
            {
                MessageBox.Show("Špatná stránka!");
                MessageBox.Show("Nebude to fungovat");
            }
        }

        private void shopsCart_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new ShopList());
        }

        private void shopsInfo_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new InfoUser());
        }

        private void Produkt_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = ((Food)Produkt_list.SelectedItem).ID;
            BackEnd.frame.Navigate(new InfoItem(id));
        }
    }
}
