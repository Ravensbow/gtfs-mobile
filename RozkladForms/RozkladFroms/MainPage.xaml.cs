using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RozkladForms
{
    public partial class MainPage : ContentPage
    {
        List<string> pobrane_Miasta= new List<string>();
        
        Kursy kierunki;
        Dane dane;
        ALIEN alien;
        string wybMiaso;
        PrzystankiGodziny Godziny;

        public MainPage(List<string>pobMias,Dane ko,string wybraneMiasto)
        {

            wybMiaso = wybraneMiasto;
            pobrane_Miasta = pobMias;
            dane = ko;
            Linie kom = new Linie(wybraneMiasto, dane);
            
            kierunki = new Kursy(wybraneMiasto, ko);
            
            Godziny = new PrzystankiGodziny(wybraneMiasto, dane);
            alien = new ALIEN(Godziny.stop_Times, kierunki.trips);
            
            InitializeComponent();
            

            for (int i = 0; i < Navigation.NavigationStack.Count; i++)
            {
                if (Navigation.NavigationStack[i] != this) Navigation.RemovePage(Navigation.NavigationStack[i]);
            }

            Conentpejdz.Title = wybraneMiasto;

            int kolumna = 0;int rzad = 0;
            for (int i = 0; i <kom.routes.Count ; i++)
            {
                if (kom.routes[i].route_short_name != null && kom.routes[i].route_short_name!=string.Empty)
                {
                    PrzyciskLinia b1 = new PrzyciskLinia(kom.routes[i]);
                    var a = new TapGestureRecognizer();
                    a.Tapped += async (s, e) => 
                    {
                        List<string> kier = new List<string>(alien.Kierunki(b1.liniaZprzyisku.route_id));
                        var action = await DisplayActionSheet("Linia nr "+b1.liniaZprzyisku.route_short_name, "Anuluj", null,kier.ToArray<string>());
                        if (action != "Anuluj")
                        {
                            string t= null;
                            foreach(string T in kier)
                            {
                                if(T==action)
                                {
                                    t = T;
                                    break;
                                }
                            }
                            await Navigation.PushAsync(new ListViewPage1(dane, t, b1.liniaZprzyisku.route_id, wybMiaso,alien));
                        }



                    };
                    b1.GestureRecognizers.Add(a);
                   
                    Laj.Children.Add(b1, kolumna, rzad);
                    if (kolumna == 4)
                    {
                        Laj.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                        rzad++;
                        kolumna = 0;
                    }
                    else kolumna++;
                }
            }
            
        }
        async void OnZmien(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Miasta:", "Anuluj", null, dane.ListaPobranych().ToArray<string>());
            var kom = DependencyService.Get<ITosty>();
            if (action!="Anuluj")
            {
                kom.LongTost("Zmiana na " + action);
                Conentpejdz.Title = action;
                await Navigation.PushAsync(new MainPage(dane.ListaPobranych(), dane, action));
            }
            
        }            
        async void OnMen(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pobieranie(dane));
        }
       
    }
}
