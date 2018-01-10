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
using Newtonsoft.Json;
using Order66.JsonParsee;
using Order66.Interface;
using Order66.Entity;
using System.Net;

namespace Order66
{
    /// <summary>
    /// Interakční logika pro LoginUser.xaml
    /// </summary>
    public partial class LoginUser : Page
    {
        User u;
        string login;
        string helo;

        public LoginUser()
        {
            InitializeComponent();
        }
        private void GetUser()
        {
            try
            {
                helo=loginPassword.Text;
                login = loginLogin.Text;

                var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/4ITB/Order-system/Users/dotaz.php?Login=" + login + "&Password=" + helo);
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                IRestResponse response = client.Execute(request);
                HttpStatusCode stat = response.StatusCode;
                if (stat == HttpStatusCode.OK)
                {
                    IParse parser = new JsonParser();
                    string result = response.Content.Replace(@"[", "");
                    result = result.Replace(@"]", "");
                    MessageBox.Show(response.Content);
                    u = JsonConvert.DeserializeObject<User>(result);
                }
                else
                {
                    MessageBox.Show("Špatná stránka!");
                    MessageBox.Show("Nebude to fungovat");
                }
            }
            catch
            {
                MessageBox.Show("Nefunguje ti to co");
            }
        }

        private void logining_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetUser();
                if (loginLogin.Text == u.Login && loginPassword.Text == u.Password)
                {
                    BackEnd.frame.Navigate(new ShopList());
                }
            }
            catch
            {
                MessageBox.Show("Furt ti to nefunguje co");
            }
        }
    }
}
