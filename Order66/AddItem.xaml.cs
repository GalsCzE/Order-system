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
using Order66.Entity;
using RestSharp;
using Order66.Framy;

namespace Order66
{
    /// <summary>
    /// Interakční logika pro AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {

        string url;

        public AddItem()
        {
            InitializeComponent();
        }

        private void Create()
        {
            try
            {
                Food fo = new Food();
                fo.Nazev = Inazev.Text;
                fo.Cena = Convert.ToInt32(Icena.Text);
                fo.Datum = DateTime.Today;
                url = "https://student.sps-prosek.cz/~sevcima14/4ITB/Order-system/Item/Insert.php";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(fo), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            catch
            {
                MessageBox.Show("Vyskytla se chyba");
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Create();
            BackEnd.frame.Navigate(new Jidelna());
            Inazev.Text = "";
            Icena.Text = "";
        }

            private void backi_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new Jidelna());
        }
    }
}
