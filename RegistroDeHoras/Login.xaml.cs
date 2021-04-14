using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistroDeHoras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        public string WebAPIKey = "AIzaSyAWsY1ZFUAAgFvhIwA8OWCr9QHD1mF7Fjc";

        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));

            try
            {

                var auth = await authProvider.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPswd.Text);

                var content = await auth.GetFreshAuthAsync(); //loguearse una sola vez

                var serializedContent = JsonConvert.SerializeObject(content); //serializar los idToken

                Preferences.Set("MyFirebaseRefreshToken", serializedContent); //añadirlo a las preferencias de xamarin essencials

                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Alert", "Usuario o contraseña incorrectos", "OK");

            }

        }

        private void btnGoToRegister_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Register());

        }
    }
}