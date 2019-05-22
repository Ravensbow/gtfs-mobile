using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace RozkladForms
{
    public  class Kalendarz
    {

        public List<Calendar> calendar = new List<Calendar>(); string[] klucz_calendar;
        public Kalendarz(string miasto, Dane dane)
        {
            string[] linijki;
            linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/calendar.txt");
            klucz_calendar = linijki[0].Split(',');

            foreach (string s in linijki)
            {

                calendar.Add(new Calendar(s, klucz_calendar));

            }
        }
    }
}