using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Order66.Entity;
using Order66.Framy;
using Order66.Interface;
using Order66.JsonParsee;
using RestSharp;

namespace Order66
{
    /// <summary>
    /// Interakční logika pro ShopList.xaml
    /// </summary>
    public partial class ShopList : Page
    {
        Food f;

        public ShopList()
        {
            InitializeComponent();
            HelloThere();
        }

        public async Task HelloThere()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/4ITB/Order-system/Users/dotaz_kart.php");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            // if (response.ResponseStatus == RestSharp.ResponseStatus.Completed) {
            HttpStatusCode stat = response.StatusCode;
            if (stat == HttpStatusCode.OK)
            {
                IParse parser = new JsonParser();
                Produkt.ItemsSource = await parser.ParseString<List<KART>>(response.Content);
            }
            else
            {
                MessageBox.Show("Špatná stránka!");
                MessageBox.Show("Nebude to fungovat");
            }
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
            MessageBox.Show("Nemáš peníze!! Nic si nekoupíš!");
        }
    }
}
