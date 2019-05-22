using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozkladForms
{
    public class GodzinyOdjazdu
    {
        public Routes Linia = new Routes();
        public List<Trips> Tripy = new List<Trips>();
        public Stops Przystanek = new Stops();
        public List<string> ostateczneGodziny = new List<string>();
        public List<string> poniedzialek = new List<string>();
        public List<string> wtorek = new List<string>();
        public List<string> sroda = new List<string>();
        public List<string> czwartek = new List<string>();
        public List<string> piatek = new List<string>();
        public List<string> sobota = new List<string>();
        public List<string> niedziela = new List<string>();
        

        public GodzinyOdjazdu(Komunikacja kom)
        {
            Linia = kom.listaPrzystankow.route;
            string kierunek = kom.listaPrzystankow.kierunek;
            Przystanek = kom.listaPrzystankow.wybrany;

           
           
            //--------------------------------
            foreach (Trips T in kom.trips)
            {
                if (T.route_id == Linia.route_id && T.trip_headsign.Replace("/", " ") == kierunek.Replace("/", " "))
                {
                    
                    foreach (Calendar C in kom.calendar)
                    {
                      
                        if (C.service_id == T.service_id)
                        {
                            
                            if (C.monday == "1")
                            {
                                Tripy.Add(T);
                                
                            }
                        }
                    }

                }
            }
           // 
            foreach (Stop_times Times in kom.stop_Times)
            {
                foreach (Trips T in Tripy)
                {
                    if (Times.stop_id == Przystanek.stop_id && Times.trip_id == T.trip_id)
                    {
                        poniedzialek.Add(Times.departure_time);
                    }
                }
            }
            
            poniedzialek.Sort();
            Tripy.Clear();
            //--------------------------------
            foreach (Trips T in kom.trips)
            {
                if (T.route_id == Linia.route_id && T.trip_headsign.Replace("/", " ") == kierunek.Replace("/", " "))
                {

                    foreach (Calendar C in kom.calendar)
                    {
                        if (C.service_id == T.service_id)
                        {
                            if (C.tuesday == "1") Tripy.Add(T);
                            
                        }
                    }

                }
            }
            
            foreach (Stop_times Times in kom.stop_Times)
            {
                foreach (Trips T in Tripy)
                {
                    if (Times.stop_id == Przystanek.stop_id && Times.trip_id == T.trip_id)
                    {
                        wtorek.Add(Times.departure_time);
                    }
                }
            }
            wtorek.Sort();
            Tripy.Clear();
            //--------------------------------
            foreach (Trips T in kom.trips)
            {
                if (T.route_id == Linia.route_id && T.trip_headsign.Replace("/", " ") == kierunek.Replace("/", " "))
                {

                    foreach (Calendar C in kom.calendar)
                    {
                        if (C.service_id == T.service_id)
                        {
                            if (C.wednesday == "1") Tripy.Add(T);
                        }
                    }

                }
            }
            foreach (Stop_times Times in kom.stop_Times)
            {
                foreach (Trips T in Tripy)
                {
                    if (Times.stop_id == Przystanek.stop_id && Times.trip_id == T.trip_id)
                    {
                        sroda.Add(Times.departure_time);
                    }
                }
            }
            sroda.Sort();
            Tripy.Clear();
            //--------------------------------
            foreach (Trips T in kom.trips)
            {
                if (T.route_id == Linia.route_id && T.trip_headsign.Replace("/", " ") == kierunek.Replace("/", " "))
                {

                    foreach (Calendar C in kom.calendar)
                    {
                        if (C.service_id == T.service_id)
                        {
                            if (C.thursday == "1") Tripy.Add(T);
                        }
                    }

                }
            }
            foreach (Stop_times Times in kom.stop_Times)
            {
                foreach (Trips T in Tripy)
                {
                    if (Times.stop_id == Przystanek.stop_id && Times.trip_id == T.trip_id)
                    {
                        czwartek.Add(Times.departure_time);
                    }
                }
            }
            czwartek.Sort();
            Tripy.Clear();
            //--------------------------------
            foreach (Trips T in kom.trips)
            {
                if (T.route_id == Linia.route_id && T.trip_headsign.Replace("/", " ") == kierunek.Replace("/", " "))
                {

                    foreach (Calendar C in kom.calendar)
                    {
                        if (C.service_id == T.service_id)
                        {
                            if (C.friday == "1") Tripy.Add(T);
                        }
                    }

                }
            }
            foreach (Stop_times Times in kom.stop_Times)
            {
                foreach (Trips T in Tripy)
                {
                    if (Times.stop_id == Przystanek.stop_id && Times.trip_id == T.trip_id)
                    {
                        piatek.Add(Times.departure_time);
                    }
                }
            }
            piatek.Sort();
            Tripy.Clear();
            //--------------------------------
            foreach (Trips T in kom.trips)
            {
                if (T.route_id == Linia.route_id && T.trip_headsign.Replace("/", " ") == kierunek.Replace("/", " "))
                {

                    foreach (Calendar C in kom.calendar)
                    {
                        if (C.service_id == T.service_id)
                        {
                            if (C.saturday == "1") Tripy.Add(T);
                        }
                    }

                }
            }
            foreach (Stop_times Times in kom.stop_Times)
            {
                foreach (Trips T in Tripy)
                {
                    if (Times.stop_id == Przystanek.stop_id && Times.trip_id == T.trip_id)
                    {
                        sobota.Add(Times.departure_time);
                    }
                }
            }
            sobota.Sort();
            Tripy.Clear();
            //--------------------------------
            foreach (Trips T in kom.trips)
            {
                if (T.route_id == Linia.route_id && T.trip_headsign.Replace("/", " ") == kierunek.Replace("/", " "))
                {

                    foreach (Calendar C in kom.calendar)
                    {
                        if (C.service_id == T.service_id)
                        {
                            if (C.sunday == "1") Tripy.Add(T);
                        }
                    }

                }
            }
            foreach (Stop_times Times in kom.stop_Times)
            {
                foreach (Trips T in Tripy)
                {
                    if (Times.stop_id == Przystanek.stop_id && Times.trip_id == T.trip_id)
                    {
                        niedziela.Add(Times.departure_time);
                    }
                }
            }
            niedziela.Sort();
            Tripy.Clear();
            
            foreach(string S in niedziela)
            {
                
            }
            //Rozklad.Godziny Mgodziny = new Rozklad.Godziny(poniedzialek, wtorek, sroda, czwartek, piatek, sobota, niedziela,kierunek,Linia.route_id,Przystanek.stop_name);
            //Mgodziny.Show();

        }
        public void WysiwetlanieGodzin()
        {
            int i = Convert.ToInt32(ostateczneGodziny[0].Substring(0, 2));
           
            Console.Write(i + ":00  |   ");
            foreach (string s in ostateczneGodziny)
            {
                
                if (i==Convert.ToInt32(s.Substring(0,2)))
                {
                    Console.Write(s + "   ");
                    
                }
                else
                {
                    Console.WriteLine();
                    i = Convert.ToInt32(s.Substring(0, 2));
                    
                    if(i<10)Console.Write(i + ":00  |   ");
                    else Console.Write(i + ":00 |   ");
                    Console.Write(s + "   ");
                }
                
            }
        }

    }
}
