﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistroDeHoras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if(!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))
            {

                MainPage = new NavigationPage(new MainPage());

            }

            else
            {

                MainPage = new NavigationPage(new Login());

            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
