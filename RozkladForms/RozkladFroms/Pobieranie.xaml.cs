using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RozkladForms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pobieranie : ContentPage
	{
        public Dane dane;
        public Pobieranie (Dane dane)
		{
           
            this.dane = dane;
			InitializeComponent ();
            for (int i = 0; i < Navigation.NavigationStack.Count; i++)
            {
                if(Navigation.NavigationStack[i]!=this)Navigation.RemovePage(Navigation.NavigationStack[i]);
            }
            SprawdzanieAktPob();
		}

        async void OnRozklad(object sender, EventArgs e)
        {
            if(ListaPobranych().Count>0) await Navigation.PushAsync(new MainPage(ListaPobranych(),dane,ListaPobranych()[0]));
            else
            {
                var kom = DependencyService.Get<ITosty>();
                kom.LongTost("Brak pobranego miasta");
            }
        }

        public void OnUsun()
        {
            foreach(string s in dane.dostepne_miasta)
            {
                dane.Usuwanie(s);
            }
            SprawdzanieAktPob();
        }

        public void OnPobieranie(object sender,EventArgs e)
        {
            List<string> miasta = WybraneSwiche();
            foreach (string s in miasta)
            {
                dane.PobierzMiasta(s);
                var kom  = DependencyService.Get<ITosty>();
                kom.LongTost("Pobrano "+s);
            }

            SprawdzanieAktPob();
        }

        public List<string> WybraneSwiche()
        {
            List<string> wybrane = new List<string>();

            if (sPoznan.On == true) wybrane.Add(sPoznan.Text);
            if (sBydgoszcz.On == true) wybrane.Add(sBydgoszcz.Text);
            if (sSzczecin.On == true) wybrane.Add(sSzczecin.Text);
            if (sWroclaw.On == true) wybrane.Add(sWroclaw.Text);


            return wybrane;
        }
        public void SprawdzanieAktPob()
        {
            foreach (string s in dane.dostepne_miasta)
            {
                if (dane.SprawdzanieAktualnosci(s) != true && s == "Poznan") { aktPoznan.Text = "Aktualne"; aktPoznan.TextColor = Color.ForestGreen; }
                else if (s == "Poznan") { aktPoznan.Text = "Nieaktualne"; aktPoznan.TextColor = Color.Red; }

                if (System.IO.File.Exists(dane.GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Poznan") { pobPoznan.Text = "Pobrane"; pobPoznan.TextColor = Color.ForestGreen; }
                else if (s == "Poznan") { pobPoznan.Text = "Niepobrane"; pobPoznan.TextColor = Color.Red; }
                //
                if (dane.SprawdzanieAktualnosci(s) != true && s == "Wroclaw") { aktWroclaw.Text = "Aktualne"; aktWroclaw.TextColor = Color.ForestGreen; }
                else if (s == "Wroclaw") { aktWroclaw.Text = "Nieaktualne"; aktWroclaw.TextColor = Color.Red; }

                if (System.IO.File.Exists(dane.GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Wroclaw") { pobWroclaw.Text = "Pobrane"; pobWroclaw.TextColor = Color.ForestGreen; }
                else if (s == "Wroclaw") { pobWroclaw.Text = "Niepobrane"; pobWroclaw.TextColor = Color.Red; }
                //
                if (dane.SprawdzanieAktualnosci(s) != true && s == "Szczecin") { aktSzczecin.Text = "Aktualne"; aktSzczecin.TextColor = Color.ForestGreen; }
                else if (s == "Szczecin") { aktSzczecin.Text = "Nieaktualne"; aktSzczecin.TextColor = Color.Red; }

                if (System.IO.File.Exists(dane.GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Szczecin") { pobSzczecin.Text = "Pobrane"; pobSzczecin.TextColor = Color.ForestGreen; }
                else if (s == "Szczecin") { pobSzczecin.Text = "Niepobrane"; pobSzczecin.TextColor = Color.Red; }
                //
                if (dane.SprawdzanieAktualnosci(s) != true && s == "Bydgoszcz") { aktBydgoszcz.Text = "Aktualne"; aktBydgoszcz.TextColor = Color.ForestGreen; }
                else if (s == "Bydgoszcz") { aktBydgoszcz.Text = "Nieaktualne"; aktBydgoszcz.TextColor = Color.Red; }

                if (System.IO.File.Exists(dane.GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Bydgoszcz") { pobBydgoszcz.Text = "Pobrane"; pobBydgoszcz.TextColor = Color.ForestGreen; }
                else if (s == "Bydgoszcz") { pobBydgoszcz.Text = "Niepobrane"; pobBydgoszcz.TextColor = Color.Red; }
            }
        }
        public List<string> ListaPobranych()
        {
            List<string> po = new List<string>();

            foreach (string s in dane.dostepne_miasta)
            {
               

                if (System.IO.File.Exists(dane.GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Poznan") { po.Add("Poznan"); }
               
                if (System.IO.File.Exists(dane.GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Wroclaw") { po.Add("Wroclaw"); }


                if (System.IO.File.Exists(dane.GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Szczecin") {po.Add("Szczecin"); }
               

                if (System.IO.File.Exists(dane.GTFS.FullName + "/" + s + "/" + s + "GTFS.zip") && s == "Bydgoszcz") { po.Add("Bydgoszcz"); }
              
            }

            return po;
        }
    }
}