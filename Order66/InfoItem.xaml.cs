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
        public InfoItem(int id)
        {
            InitializeComponent();
            ID = id;
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
    }
}
