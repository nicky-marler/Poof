﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Poof
{
    public partial class App : Application
    {

        
        public ViewModel.Poof_ViewModel Data { get; set; }

        public App()
        {
            Data = new ViewModel.Poof_ViewModel();

            InitializeComponent();
            

            MainPage = new NavigationPage( new MainPage());
        }

        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
