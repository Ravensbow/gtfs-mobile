using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RozkladForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {

        Dane d;Kalendarz kal;ALIEN alien;string Linia;string Kier; Przystanki przystanki;
        public ListViewPage1(Dane dane, string t, string linia, string miasto,ALIEN alien)
        {
            przystanki = new Przystanki(miasto, dane);
            this.alien = alien;
            InitializeComponent();
            d = dane;
            Kier = t;
            Linia = linia;
            
            
            kal = new Kalendarz(miasto, dane);
            List<string> Items =alien.Przystanki(t,linia,przystanki.stops,false);

            MyListView.ItemsSource = Items.ToArray<string>();
            
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            string s = e.Item.ToString().Substring(0, e.Item.ToString().IndexOf('.'));

            System.Diagnostics.Debug.WriteLine("GOWNO "+Convert.ToInt64( s));
            await Navigation.PushAsync(new ScrollableTabbedPage(alien,kal,Linia,Kier,alien.Przystanki(Kier,Linia,przystanki.stops,true)[Convert.ToInt32(s)]));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
