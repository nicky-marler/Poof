using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Poof
{
    public partial class App : Application
    {
        public App()
        {
            decimal x = 7;
            decimal y = 8;
            decimal z = x / y;
            z = Math.Round(z*100,1);
            decimal a = z * 100;

            InitializeComponent();
            

            MainPage = new Poof.MainPage();
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
