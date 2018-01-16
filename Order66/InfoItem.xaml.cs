using Order66.Entity;
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
using RestSharp;
using Newtonsoft.Json;
using Order66.Framy;
using System.Net;
using Order66.Interface;
using Order66.JsonParsee;

namespace Order66
{
    /// <summary>
    /// Interakční logika pro InfoItem.xaml
    /// </summary>
    public partial class InfoItem : Page
    {
        Food f;
        int ID;
        int nice;

        public InfoItem(int id, int idd)
        {
            InitializeComponent();
            ID = id;
            nice = idd;
            GetFood();
            Itemid.Content = f.ID;
            Itemnazev.Content = f.Nazev;
            Itemcena.Content = f.Cena.ToString() + " Kč";
            Itemdatum.Content = f.Datum.ToString();
        }

        public InfoItem(int id)
        {
            InitializeComponent();
            ID = id;
            GetFood();
            Itemid.Content = f.ID;
            Itemnazev.Content = f.Nazev;
            Itemcena.Content = f.Cena.ToString() + " Kč";
            Itemdatum.Content = f.Datum.ToString();
        }

        private void GetFood()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/4ITB/Order-system/Item/dotaz.php?ID=" + ID);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            HttpStatusCode stat = response.StatusCode;
            if (stat == HttpStatusCode.OK)
            {
                IParse parser = new JsonParser();
                string result = response.Content.Replace(@"[", "");
                result = result.Replace(@"]", "");
                f = JsonConvert.DeserializeObject<Food>(result);
            }
            else
            {
                MessageBox.Show("Špatná stránka!");
                MessageBox.Show("Nebude to fungovat");
            }
        }

        private void backintime_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new Jidelna());
        }

        private void Buyitem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KART usa = new KART();
                usa.Uzivatel = nice;
                usa.Produkt = f.ID;

                string url = "https://student.sps-prosek.cz/~sevcima14/4ITB/Order-system/Users/Insert_Kart.php";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(usa), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                MessageBox.Show("Máš to v košíku!");
            }
            catch
            {
                MessageBox.Show("Vyskytla se chyba");
            }
        }

        private void Itemdelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
