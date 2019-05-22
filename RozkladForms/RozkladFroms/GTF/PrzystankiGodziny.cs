using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RozkladForms
{
    public class PrzystankiGodziny
    {
        public List<Stop_times> stop_Times = new List<Stop_times>(); string[] klucz_stops_times;
        public PrzystankiGodziny(string miasto, Dane dane)
        {
            string[] linijki;

            linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/stop_times.txt");
            klucz_stops_times = linijki[0].Split(',');

            foreach (string s in linijki)
            {

                stop_Times.Add(new Stop_times(s, klucz_stops_times));


            }
        }
        public PrzystankiGodziny(string miasto, Dane dane,string t_id)
        {
            string[] linijki;

            linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/stop_times.txt");
            klucz_stops_times = linijki[0].Split(',');

            foreach (string s in linijki)
            {
                stop_Times.Add(Stop_times.CreateStop_times(s,klucz_stops_times,t_id));
            }
        }
    }
}
