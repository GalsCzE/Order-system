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
using Newtonsoft.Json;
using Order66.Entity;
using Order66.Framy;
using Order66.Interface;
using Order66.JsonParsee;
using RestSharp;

namespace Order66
{
    /// <summary>
    /// Interakční logika pro InfoUser.xaml
    /// </summary>
    public partial class InfoUser : Page
    {
        User u;
        int iid;

        public InfoUser(int IDuserss)
        {
            InitializeComponent();
            iid = IDuserss;
            GETUser();
            Userjmeno.Text = u.Name;
            Userprijmeni.Text = u.Surname;
            Userlog.Text = u.Login;
            Userheslo.Text = u.Password;
        }

        private void GETUser()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/4ITB/Order-system/Users/dotaz_user.php?ID=" + iid);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            HttpStatusCode stat = response.StatusCode;
            if (stat == HttpStatusCode.OK)
            {
                IParse parser = new JsonParser();
                string result = response.Content.Replace(@"[", "");
                result = result.Replace(@"]", "");
                u = JsonConvert.DeserializeObject<User>(result);
            }
            else
            {
                MessageBox.Show("Špatná stránka!");
                MessageBox.Show("Nebude to fungovat");

            }
        }

            private void back_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new Jidelna());
        }
    }
}
