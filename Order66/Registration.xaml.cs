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
using Order66.Framy;
using RestSharp;

namespace Order66
{
    /// <summary>
    /// Interakční logika pro Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        string url;

        public Registration()
        {
            InitializeComponent();
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User us = new User();
                us.Name = registrationName.Text;
                us.Surname = registrationSurname.Text;
                us.Login = registrationLogin.Text;
                us.Password = registrationPassword.Password;

                url = "https://student.sps-prosek.cz/~sevcima14/4ITB/Order-system/Users/Insert.php";
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(us), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                MessageBox.Show("Úspěšně jste se zaregistroval!");

                registrationName.Text = "";
                registrationSurname.Text = "";
                registrationLogin.Text = "";
                registrationPassword.Password = "";

                BackEnd.frame.Navigate(new LoginUser());
            }
            catch
            {
                MessageBox.Show("Vyskytla se chyba");
            }
        }

        private void traceLogin_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new LoginUser());
        }
    }
}
