using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RegistroDeHoras
{
    public partial class MainPage : ContentPage
    {

        public string WebAPIKey = "AIzaSyAWsY1ZFUAAgFvhIwA8OWCr9QHD1mF7Fjc";

        public MainPage()

        {
            InitializeComponent();

            GetProfileInformationAndRefreshToken();

        }

        private async void GetProfileInformationAndRefreshToken()
        {

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));

            try
            {

                //firebase authentication guardada durante el login
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));

                //Refrescamos el token
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);

                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);

                await App.Current.MainPage.DisplayAlert("Alerta", "Sesión caducada.", "OK");

            }

        }
      
    }

}
