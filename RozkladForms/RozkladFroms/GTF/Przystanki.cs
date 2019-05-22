using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace RozkladForms
{
    public class Przystanki
    {
        public List<Stops> stops = new List<Stops>(); string[] klucz_stops;
        public Przystanki(string miasto,Dane dane)
        {
            string[] linijki;

            linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/stops.txt");
            klucz_stops = linijki[0].Split(',');

            foreach (string s in linijki)
            {

                stops.Add(new Stops(s, klucz_stops));

            }

        }
    }
}
