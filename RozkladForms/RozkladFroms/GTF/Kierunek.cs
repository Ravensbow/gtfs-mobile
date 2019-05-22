using System;
using System.Collections.Generic;
using System.Text;

namespace RozkladForms
{
    public class Kierunek
    {
        public List<Stops> przystanki = new List<Stops>();
        public List<Stop_times> przysGodz = new List<Stop_times>();
        public string HeadSign;

        public Kierunek(string nazwa)
        {
            HeadSign = nazwa;
        }
    }
}
