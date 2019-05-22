using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RozkladForms
{
    public class Kursy
    {
        public List<Trips> trips = new List<Trips>(); string[] klucz_trips;

        public Kursy(string miasto,Dane dane)
        {
            string[] linijki;

            linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/trips.txt");
            klucz_trips = linijki[0].Split(',');

            foreach (string s in linijki)
            {

                trips.Add(new Trips(s, klucz_trips));

            }
        }

        public Kursy(string miasto, Dane dane,string r_id)
        {
            string[] linijki;

            linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/trips.txt");
            klucz_trips = linijki[0].Split(',');

            foreach (string s in linijki)
            {

                trips.Add(new Trips(s, klucz_trips,r_id));
                if (trips[trips.Count - 1].route_id == "usun") trips.RemoveAt(trips.Count - 1);
            }
        }
    }
}
