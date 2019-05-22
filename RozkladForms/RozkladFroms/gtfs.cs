using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace RozkladForms
{
    public class Agency
    {
        public string agency_id;
        public string agency_name;
        public string agency_url;
        public string agency_time_zone;
        public string agency_phone;
        public string agency_lang;

        public Agency(string linia,string[] klucz)
        {
            string[] parametry = linia.Split(',');
            for (int f = 0; f < klucz.Length; f++)
            {
                klucz[f] = klucz[f].Replace("\"", "");
            }

            for (int i = 0; i < klucz.Length; i++)
            {
                if (klucz[i] == "agency_id") agency_id = parametry[i].Replace("\"", "");
                else if (klucz[i] == "agency_name") agency_name = parametry[i].Replace("\"", "");
                else if (klucz[i] == "agency_url") agency_url = parametry[i].Replace("\"", "");
                else if (klucz[i] == "agency_timezone") agency_time_zone = parametry[i].Replace("\"", "");
                else if (klucz[i] == "agency_phone") agency_phone = parametry[i].Replace("\"", "");
                else if (klucz[i] == "agency_lang") agency_lang = parametry[i].Replace("\"", "");
            }

        }
        public void Wyswietl()
        {
            Console.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}", agency_id, agency_name, agency_url, agency_time_zone, agency_phone, agency_lang);
        }
    }
    public class Calendar
    {
        public string service_id;
        public string monday;
        public string tuesday;
        public string wednesday;
        public string thursday;
        public string friday;
        public string saturday;
        public string sunday;
        public string start_date, end_date;

        public Calendar(string linia,string[] klucz)
        {
            string[] parametry = linia.Split(',');
            for (int f = 0; f < klucz.Length; f++)
            {
                klucz[f] = klucz[f].Replace("\"", "");
            }
            if (parametry[0] != "service_id")
            {
                for (int i = 0; i < klucz.Length; i++)
                {
                    if (klucz[i] == "service_id") service_id = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "monday") monday = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "tuesday") tuesday = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "wednesday") wednesday = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "thursday") thursday = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "friday") friday = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "saturday") saturday = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "sunday") sunday = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "start_date") start_date = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "end_date") end_date = parametry[i].Replace("\"", "");
                }
            }
            else service_id = "-1";
        }

    }
    public class Feed_info
    {
        public string feed_publisher_name, feed_publisher_url, feed_lang, feed_start_date, feed_end_date;

        public Feed_info(string linia,string[] klucz)
        {
            for (int f = 0; f < klucz.Length; f++)
            {
                klucz[f] = klucz[f].Replace("\"", "");
            }
            string[] parametry = linia.Split(',');
            if (parametry[0] != "feed_publisher_name")
            {
                for (int i = 0; i < klucz.Length; i++)
                {
                    if (klucz[i] == "feed_publisher_name") feed_publisher_name = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "feed_publisher_url") feed_publisher_url = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "feed_lang") feed_lang = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "feed_start_date") feed_start_date = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "feed_end_date") feed_end_date = parametry[i].Replace("\"", "");
                }

            }
        }
    }

    public class Routes
    {
        public string route_id;
        public string agency_id; public Agency agency;
        public string route_short_name;
        public string route_long_name;
        public string route_desc; public Route_Desc desc;
        public string route_type;
        public string route_color;
        public string route_text_color;

        public Routes(string linia, List<Agency> agencys,string[] klucz)
        {
            for (int f = 0; f < klucz.Length; f++)
            {
                klucz[f] = klucz[f].Replace("\"", "");
            }
            int liczbadesc = 0;

            for (int i = 0; i < klucz.Length; i++) { if (klucz[i] == "route_desc") liczbadesc = i; }

            linia = Usuwanie(linia, liczbadesc, klucz.Length);

            string[] parametry = linia.Split(',');

            if (parametry[0].Contains( "route_id")==false && linia != string.Empty&& parametry[0] != "agency_id")
            {
                for (int i = 0; i < klucz.Length; i++)
                {
                    if (klucz[i] == "route_id") route_id = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "agency_id")
                    {
                        agency_id = parametry[i].Replace("\"", "");
                        foreach (Agency a in agencys)
                        {
                            if (a.agency_id == agency_id) agency = a;
                        }
                    }
                    else if (klucz[i] == "route_short_name") route_short_name = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "route_long_name") route_long_name = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "route_desc") route_desc = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "route_type") route_type = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "route_color") route_color = parametry[i].Replace("\"", "");
                    else if (klucz[i] == "route_text_color") route_text_color = parametry[i].Replace("\"", "");
                }
            }

        }
        public static string Usuwanie(string linia, int liczba, int dlugoscklucza)
        {
            if (linia.Contains('^'))
            {
                string snew = linia;
                for (int i = 0; i < liczba; i++)
                {
                    snew = snew.Remove(0, snew.IndexOf(',') + 1);
                }

                for (int i = dlugoscklucza; i > liczba + 1; i--)
                {
                    snew = snew.Remove(snew.LastIndexOf(','), snew.Length - (snew.LastIndexOf(',')));
                }

                string snewN = snew.Replace(',', ' ');
                linia = linia.Replace(snew, snewN);

            }
            return linia;
        }
        public Routes() { }
        public void Wyswietl_Przystanki()
        {
            foreach (string[] g in desc.przystanki)
            {
                Console.WriteLine("----" + route_short_name + ": " + route_long_name + "----");
                Console.WriteLine();
                Console.WriteLine("Obsługiwane przez:" + agency.agency_name);
                Console.WriteLine();

                foreach (string h in g)
                {
                    Console.WriteLine(h);
                }
            }
        }
        public Routes Szukaj_po_id(string szukana)
        {

            if (szukana == route_id) return this;
            else return null;
        }
    }
    public class Route_Desc
    {

        public List<string[]> przystanki = new List<string[]>();


        public Route_Desc(string s)
        {
            string[] tabGlowny = s.Split('|');
            for (int i = 0; i < tabGlowny.Length; i++)
            {
                przystanki.Add(tabGlowny[i].Split('-'));
            }

        }
        public static string Usuwanie(string linia)
        {
            string snew = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                linia = linia.Remove(0, linia.IndexOf(',') + 1);
            }
            snew = linia;
            while (snew.Contains('|') && snew.Contains('^'))
            {
                if (linia.Substring(0, linia.IndexOf('|')).Contains('^') == true)
                {
                    snew = linia.Remove(linia.IndexOf('^'), linia.IndexOf('|') - linia.IndexOf('^'));
                    if (snew.Contains('^') == true)
                    {
                        snew = snew.Remove(snew.IndexOf('^'), snew.Length - snew.IndexOf('^'));
                    }
                }
                else if (linia.Contains('^') == true)
                {
                    snew = linia.Remove(linia.IndexOf('^'), linia.Length - linia.IndexOf('^'));
                }

            }
            if (snew.Contains('^'))
            {
                snew = snew.Remove(snew.IndexOf('^'), snew.Length - snew.IndexOf('^'));
            }
            if (snew.Contains('"')) snew = snew.Remove(snew.IndexOf('"'), 1);
            string[] tab = snew.Split(',');
            //Console.WriteLine(tab[0]);
            return tab[0];
        }

    }

    public class Trips
    {
        public string route_id;
        public string service_id;
        public string trip_id;
        public string trip_headsign;
        public string direction_id; // 0-tam,1-powrot
        public string shape_id; //gowno
        public string wheelchair_accessible;

        public Trips(string s,string[] klucz)
        {
            for (int f = 0; f < klucz.Length; f++)
            {
                klucz[f] = klucz[f].Replace("\"", "");
            }
            int liczbadesc = 0;

            for (int i = 0; i < klucz.Length; i++) { if (klucz[i] == "trip_id") liczbadesc = i; }

            s = Routes.Usuwanie(s, liczbadesc, klucz.Length);

            string[] tab = s.Split(',');
            if (tab[0] != "route_id")
            {
                for (int i = 0; i < klucz.Length; i++)
                {
                    if (klucz[i] == "route_id") route_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "service_id") service_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "trip_id") trip_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "trip_headsign") trip_headsign = tab[i].Replace("\"", "").ToUpper();
                    else if (klucz[i] == "direction_id") direction_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "shape_id") shape_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "wheelchair_accessible") wheelchair_accessible = tab[i].Replace("\"", "");
                }


                //Console.WriteLine("route:{0} service:{1} trip{2} head{3} direc{4} shape{5} wuzek{6}", route_id, service_id, trip_id, trip_headsign, direction_id, shape_id, wheelchair_accessible);
            }

        }
        public Trips(string s, string[] klucz,string r_id)
        {
            for (int f = 0; f < klucz.Length; f++)
            {
                klucz[f] = klucz[f].Replace("\"", "");
            }
            int liczbadesc = 0;

            for (int i = 0; i < klucz.Length; i++) { if (klucz[i] == "trip_id") liczbadesc = i; }

            s = Routes.Usuwanie(s, liczbadesc, klucz.Length);

            string[] tab = s.Split(',');
            if (tab[0] != "route_id" && tab[0].Replace("/", " ").Replace("\"", "").ToUpper() == r_id.Replace("/", " ").Replace("\"", "").ToUpper())
            {
                for (int i = 0; i < klucz.Length; i++)
                {
                    if (klucz[i] == "route_id") route_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "service_id") service_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "trip_id") trip_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "trip_headsign") trip_headsign = tab[i].Replace("\"", "").ToUpper();
                    else if (klucz[i] == "direction_id") direction_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "shape_id") shape_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "wheelchair_accessible") wheelchair_accessible = tab[i].Replace("\"", "");
                }


                //Console.WriteLine("route:{0} service:{1} trip{2} head{3} direc{4} shape{5} wuzek{6}", route_id, service_id, trip_id, trip_headsign, direction_id, shape_id, wheelchair_accessible);
            }
            else route_id = "usun";

        }
        public static string Usuwanie(ref string s, ref string trip)
        {
            string sciecie = s.Remove(0, s.IndexOf('"') + 1);
            //Console.WriteLine(sciecie);
            string gowno = sciecie.Substring(0, sciecie.IndexOf('"'));
            //Console.WriteLine(gowno);
            s = s.Replace(gowno, "");
            //Console.WriteLine(s);
            trip = gowno;
            return s;
        }
    }
  
    public class Stops
    {
        public string stop_id;
        public string stop_code;
        public string stop_name;
        public string stop_lat, stop_lon;
        public string zone_id;

        public Stops(string s, string[] klucz)
        {
            for (int f = 0; f < klucz.Length; f++)
            {
                klucz[f] = klucz[f].Replace("\"", "");
            }
            string[] tab = s.Split(',');
            if (tab[0] != "stop_id")
            {
                for (int i = 0; i < klucz.Length; i++)
                {
                    if (klucz[i] == "stop_id") stop_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "stop_code")
                    {
                        if (tab[i].Contains('"')) tab[i] = tab[i].Remove(tab[i].IndexOf('"'), 1);
                        if (tab[i].Contains('"')) tab[i] = tab[i].Remove(tab[i].IndexOf('"'), 1);

                        stop_code = tab[i];
                    }
                    else if (klucz[i] == "stop_name")
                    {
                        if (tab[i].Contains('"')) tab[i] = tab[i].Remove(tab[i].IndexOf('"'), 1);
                        if (tab[i].Contains('"')) tab[i] = tab[i].Remove(tab[i].IndexOf('"'), 1);

                        stop_name = tab[i];
                    }
                    else if (klucz[i] == "stop_lat") stop_lat = tab[i].Replace("\"", "").ToUpper();
                    else if (klucz[i] == "stop_lon") stop_lon = tab[i];
                    else if (klucz[i] == "zone_id") zone_id = tab[i];
                }
            }
        }
        public Stops() { }

    }
    public class Stop_times : IComparable<Stop_times>
    {
        public string trip_id;
        public string arrivle_time;
        public string departure_time;
        public string stop_id;
        public string stop_sequence;
        public string stop_headsign;
        public string pickup_type;// mozna zabrac pasazerow 0-tak 1-nie
        public string drop_of_type;//mozna wysadzic 0-tak 1-nie

        public Stop_times(string s, string[] klucz)
        {
            for (int f = 0; f < klucz.Length; f++)
            {
                klucz[f] = klucz[f].Replace("\"", "");
            }
            int liczbadesc = 0;

            for (int i = 0; i < klucz.Length; i++) { if (klucz[i] == "trip_id") liczbadesc = i; }

            s = Routes.Usuwanie(s, liczbadesc, klucz.Length);

            string[] tab = s.Split(',');

            if (tab[0] != "trip_id")
            {
                for (int i = 0; i < klucz.Length; i++)
                {
                    if (klucz[i] == "trip_id") trip_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "arrival_time") arrivle_time = tab[i].Replace("\"", "");
                    else if (klucz[i] == "departure_time") departure_time = tab[i].Replace("\"", "");
                    else if (klucz[i] == "stop_id") stop_id = tab[i].Replace("\"", "").ToUpper();
                    else if (klucz[i] == "stop_sequence") stop_sequence = tab[i].Replace("\"", "");
                    else if (klucz[i] == "stop_headsign") stop_headsign = tab[i].Replace("\"", "");
                    else if (klucz[i] == "pickup_type") pickup_type = tab[i].Replace("\"", "");
                    else if (klucz[i] == "drop_off_type") drop_of_type = tab[i].Replace("\"", "");
                }
            }
        }
        public Stop_times(string[] tab, string[] klucz)
        {
            for (int i = 0; i < klucz.Length; i++)
                {
                    if (klucz[i] == "trip_id") trip_id = tab[i].Replace("\"", "");
                    else if (klucz[i] == "arrival_time") arrivle_time = tab[i].Replace("\"", "");
                    else if (klucz[i] == "departure_time") departure_time = tab[i].Replace("\"", "");
                    else if (klucz[i] == "stop_id") stop_id = tab[i].Replace("\"", "").ToUpper();
                    else if (klucz[i] == "stop_sequence") stop_sequence = tab[i].Replace("\"", "");
                    else if (klucz[i] == "stop_headsign") stop_headsign = tab[i].Replace("\"", "");
                    else if (klucz[i] == "pickup_type") pickup_type = tab[i].Replace("\"", "");
                    else if (klucz[i] == "drop_off_type") drop_of_type = tab[i].Replace("\"", "");
                }

        }
        public static Stop_times CreateStop_times(string s, string[] klucz,string t_id)
        {
            for (int f = 0; f < klucz.Length; f++)
            {
                klucz[f] = klucz[f].Replace("\"", "");
            }
            int liczbadesc = 0;

            for (int i = 0; i < klucz.Length; i++) { if (klucz[i] == "trip_id") liczbadesc = i; }

            s = Routes.Usuwanie(s, liczbadesc, klucz.Length);

            string[] tab = s.Split(',');

            if (tab[0] == t_id)
            {
                return new Stop_times(tab, klucz);
            }
            else return null;
        }
        
        public static void Usuwanie(ref string s, ref string trip)
        {
            s = s.Remove(0, 1);

            trip = s.Substring(0, s.IndexOf('"'));

            s = s.Replace(trip, "");


        }
        public void Wyswietlanie()
        {
            Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", trip_id, arrivle_time, departure_time, stop_id, stop_sequence, stop_headsign, pickup_type, drop_of_type);
        }

        public int CompareTo(Stop_times other)
        {
            return departure_time.CompareTo(other.departure_time);
        }
    }

    public class Komunikacja
    {
        public List<Agency> agency = new List<Agency>(); string[] klucz_agency;
        public List<Calendar> calendar = new List<Calendar>(); string[] klucz_calendar;
        public List<Feed_info> feed_Info = new List<Feed_info>(); string[] klucz_feed_info;
        public List<Routes> routes = new List<Routes>(); string[] klucz_routes;
        public List<Trips> trips = new List<Trips>(); string[] klucz_trips;
        public List<Stops> stops = new List<Stops>(); string[] klucz_stops;
        public List<Stop_times> stop_Times = new List<Stop_times>(); string[] klucz_stops_times;

        public Kierunki kier;
        public ListaPrzy listaPrzystankow;
        public GodzinyOdjazdu godzinyOdjazdu;
       

        public Komunikacja(string miasto,Dane dane)
        {
            string[] linijki;

            try
            {
                linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/agency.txt");
                klucz_agency = linijki[0].Split(',');

                foreach (string s in linijki)
                {

                    agency.Add(new Agency(s,klucz_agency));

                }
             

                linijki = File.ReadAllLines(dane.GTFS.FullName+"/" + miasto + "/calendar.txt");
                klucz_calendar = linijki[0].Split(',');

                foreach (string s in linijki)
                {

                    calendar.Add(new Calendar(s,klucz_calendar));

                }
                if (File.Exists(dane.GTFS.FullName + "/" + "/feed_info.txt"))
                {
                    linijki = File.ReadAllLines("GTFS/" + miasto + "/feed_info.txt");
                    if (linijki.Length > 0) klucz_feed_info = linijki[0].Split(',');

                    foreach (string s in linijki)
                    {

                        feed_Info.Add(new Feed_info(s, klucz_feed_info));

                    }
                }
                linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto+ "/routes.txt");
                klucz_routes = linijki[0].Split(',');

                foreach (string s in linijki)
                {

                    routes.Add(new Routes(s, agency,klucz_routes));

                }
                
                linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/trips.txt");
                klucz_trips = linijki[0].Split(',');

                foreach (string s in linijki)
                {

                    trips.Add(new Trips(s,klucz_trips));

                }
                
                linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/stops.txt");
                klucz_stops = linijki[0].Split(',');

                foreach (string s in linijki)
                {

                    stops.Add(new Stops(s,klucz_stops));

                }
                
                linijki = File.ReadAllLines(dane.GTFS.FullName + "/" + miasto + "/stop_times.txt");
                klucz_stops_times = linijki[0].Split(',');

                foreach (string s in linijki)
                {

                    stop_Times.Add(new Stop_times(s,klucz_stops_times));
                    

                }
                
                //routes[5].Wyswietl_Przystanki();


               

            }
            catch (FileLoadException ioe)
            {
                Console.WriteLine("Blad odczytu: " + ioe);
            }
            finally
            {
                linijki = null;
            }
        }


        //public FlowLayoutPanel F_DodajLinie(FlowLayoutPanel flow)
        //{
        //    int i = 0;
        //    foreach (Routes R in routes)
        //    {
        //        if (R.route_id != null)
        //        {
        //            Rozklad.ButtonLinia L = addLabel(R);
        //            flow.Controls.Add(L);
        //            L.Click += new EventHandler(this.labelClick);
        //        }
        //    }
        //    return flow;
        //}

        //private void labelClick(object sender, EventArgs e)
        //{
        //    Rozklad.ButtonLinia obecna = (Rozklad.ButtonLinia)sender;
        //    //MessageBox.Show(obecna.Text);

        //    kier = new Kierunki(obecna.linia,this);
        //    listaPrzystankow = new ListaPrzystankow(this);
        //    godzinyOdjazdu = new GodzinyOdjazdu(this);

        //}

        //Rozklad.ButtonLinia addLabel(gtf.Routes Rout)
        //{
        //     Rozklad.ButtonLinia L = new Rozklad.ButtonLinia();

        //    L.Name = Rout.route_id;
        //    L.Text = Rout.route_short_name;
        //    if(Rout.route_text_color != null&& Rout.route_text_color != string.Empty&& Rout.route_text_color != "route_text_color") L.ForeColor =ColorTranslator.FromHtml( "#"+ Rout.route_text_color);

        //    if (Rout.route_color != null && Rout.route_color != string.Empty && Rout.route_color != "route_color") L.BackColor = ColorTranslator.FromHtml("#" + Rout.route_color);
        //    else L.BackColor = Color.ForestGreen;
        //    L.Font = new Font("Serif", 15, FontStyle.Bold);
        //    L.Width = 65;
        //    L.Height = 40;
        //    L.TextAlign = ContentAlignment.MiddleCenter;
        //    L.Margin = new Padding(5);
        //    L.linia = Rout;
        //    return L;

        //}





        public void WyswietlPrzystanek(Stops r)
        {
            Console.WriteLine("--" + r.stop_id + "--" + r.stop_name + "--" + r.stop_code + "--");
            foreach (Stop_times tim in stop_Times)
            {
                if (tim.stop_id == r.stop_id)
                {
                    foreach (Trips tri in trips)
                    {
                        if (tim.trip_id == tri.trip_id)
                        {
                            Console.WriteLine("Linia nr: " + tri.route_id);
                            Console.WriteLine("Godzina odjazdu: " + tim.departure_time + " W kierunku: " + tim.stop_headsign);
                        }
                    }
                }
            }
        }
    }
}
