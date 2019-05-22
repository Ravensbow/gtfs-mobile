using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace RozkladForms
{
    public class Linie
    {
        public List<Routes> routes = new List<Routes>(); string[] klucz_routes;
        public List<Agency> agency = new List<Agency>(); string[] klucz_agency;

        public Linie(string miasto, Dane dane)
        {
            string[] linijki;

            linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/agency.txt");
            klucz_agency = linijki[0].Split(',');

            foreach (string s in linijki)
            {

                agency.Add(new Agency(s, klucz_agency));

            }

            linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/routes.txt");
            klucz_routes = linijki[0].Split(',');

            foreach (string s in linijki)
            {

                routes.Add(new Routes(s, agency, klucz_routes));

            }
        }

        public static List<Trips> ListaKierunkow(string miasto,Dane dane,Routes linia,Kursy kursy)
        {
            

            List<Trips> przykladoweTripy = new List<Trips>();
            List<string> lista = new List<string>();
            foreach (Trips t in kursy.trips) { System.Diagnostics.Debug.WriteLine(t.route_id+":"+linia.route_id); }
          

            for (int i = 0; i < kursy.trips.Count; i++)
            {
                if (przykladoweTripy.Any(p => p.trip_headsign.Replace("/", " ").Replace("\"","").ToUpper() == kursy.trips[i].trip_headsign.Replace("/", " ").Replace("\"", "").ToUpper()) == false && kursy.trips[i].route_id.Replace("/", " ").Replace("\"", "").ToUpper() == linia.route_id.Replace("/", " ").Replace("\"", "").ToUpper())
                {
                    przykladoweTripy.Add(kursy.trips[i]);
                    lista.Add(kursy.trips[i].trip_headsign);
                }

            }
            return przykladoweTripy;
        }
        public static List<Stop_times> ListaPrzystankow(Dane dane,string t_id,Routes linia,string miasto, PrzystankiGodziny PG)
        {
            List<Stop_times> przystanki = new List<Stop_times>();
          

            int znalazlo = 0;

            foreach (Stop_times S in PG.stop_Times)
            {
                if (S.trip_id == t_id)
                {
                    znalazlo = 1;
                    przystanki.Add(S);
                }
                else if(znalazlo==1)
                {
                    break;
                }
            }

            przystanki.Sort();



            return przystanki;
        }
    }
}
