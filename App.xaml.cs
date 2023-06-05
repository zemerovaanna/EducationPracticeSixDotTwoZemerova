using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineCookery
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PageChoiceCake(0, 25));
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
