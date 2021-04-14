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
    public partial class Register : ContentPage
    {

        public string WebAPIKey = "AIzaSyAWsY1ZFUAAgFvhIwA8OWCr9QHD1mF7Fjc"; 

        public Register()
        {

            InitializeComponent();

        }

        private async void btnRegister_Clicked(object sender, EventArgs e) //Registrarse
        {

            try
            {

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey)); //configurar firebase gracias a la api

                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(txtUserEmail.Text, txtPswd.Text); //dar de alta al nuevo usuario

                string gettoken = auth.FirebaseToken;

                await App.Current.MainPage.DisplayAlert("Alert", "¡Registro realizado con éxito!", "OK");

                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");

            }

        }

        private void btnGoToLogin_Clicked(object sender, EventArgs e) //Ir al login
        {

            Navigation.PushAsync(new Login());

        }
    }
}