using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RozkladForms
{
    
    public partial class App : Application
    {
        public Dane dane;
        public PrzystankiGodziny godz;
        public App()
        {
            InitializeComponent();
            dane = new Dane();
            if(dane.ListaPobranych().Count>0)
            {
                
                MainPage = new NavigationPage(new MainPage(dane.ListaPobranych(),dane,dane.ListaPobranych()[0]));
            }
            else MainPage = new NavigationPage(new Pobieranie(dane));
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
