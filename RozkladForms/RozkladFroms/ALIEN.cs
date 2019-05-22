using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RozkladForms
{
    
    public class ALIEN
    {
        public List<TRIP_ALIEN> ts = new List<TRIP_ALIEN>();

        public ALIEN(List<Stop_times> stop_Times, List<Trips> trips)
        {
            ts.Add(new TRIP_ALIEN(" ", " ", " ", " "));
            foreach (Stop_times ST in stop_Times)
            {

                if (ts[ts.Count - 1].trip_id == ST.trip_id)
                {



                    ts[ts.Count - 1].odjazd.Add(new ODJAZD_ALIEN(ST.stop_id, ST.departure_time));

                }
                else
                {

                    ts.Add(new TRIP_ALIEN(ST.trip_id, ST.stop_id, ST.departure_time, ST.stop_headsign));
                }

            }
            ts.RemoveAt(0);
            trips = trips.OrderBy(p => p.trip_id).ToList();
            for (int i = 0; i < trips.Count; i++)
            {
                if (trips[i].trip_id == null) trips.RemoveAt(i);
                if (i > 0 && trips[i].trip_id != null)
                {
                    if (trips[i].trip_id.Substring(0, trips[i].trip_id.IndexOf('^') + 1) == trips[i - 1].trip_id.Substring(0, trips[i - 1].trip_id.IndexOf('^') + 1))
                    {
                        trips.RemoveAt(i);
                        i--;
                    }
                }
            }
            ts = ts.OrderBy(a => a.trip_id).ToList();
            for (int i = 0; i < ts.Count; i++)
            {
                if (ts[i].trip_id == null) ts.RemoveAt(i);
                if (i > 0 && ts[i].trip_id != null)
                {
                    if (ts[i].trip_id.Substring(0, ts[i].trip_id.IndexOf('^') + 1) == ts[i - 1].trip_id.Substring(0, ts[i - 1].trip_id.IndexOf('^') + 1))
                    {
                        ts.RemoveAt(i);
                        i--;
                    }
                }
            }

            for (int i = 0; i < ts.Count; i++)
            {
                ts[i].service_id = trips[i].service_id;
                ts[i].route_id = trips[i].route_id;
                ts[i].head = trips[i].trip_headsign;
            }

        }

        internal List<string> Godziny(string wybranalinia, string wybranykierunek, string wybranyprzystanek, string wybranydzien, List<Calendar> cal)
        {


            List<string> serwisy = new List<string>(Serwisy(wybranydzien, cal));

            List<string> odjazd = new List<string>();
            foreach (TRIP_ALIEN ta in ts)
            {
                if (ta.route_id == wybranalinia)
                {
                    if (ta.head == wybranykierunek)
                    {
                        if (serwisy.Contains(ta.service_id))
                        {
                            foreach (ODJAZD_ALIEN oa in ta.odjazd)
                            {
                                if (oa.stop_id == wybranyprzystanek)
                                {
                                    odjazd.Add(oa.departure);
                                }
                            }
                        }
                    }
                }
            }
            odjazd.Sort();
            return odjazd;
        }

        public List<string> Przystanki(string wybranykierunek, string wybranalinia, List<Stops> stope,bool id)
        {

            List<string> ss = new List<string>();
            foreach (TRIP_ALIEN t in ts)
            {
                if (t.head == wybranykierunek && t.route_id == wybranalinia)
                {

                    ss = t.odjazd.OrderBy(h => h.departure).ToList().Select(k => k.stop_id).ToList();
                    break;
                }
            }
            List<string> sskopia = new List<string>(ss);
           
            foreach (Stops sto in stope)
            {
                if (ss.Contains(sto.stop_id))
                {
                    ss[ss.IndexOf(sto.stop_id)] = sto.stop_name;
                    
                }
            }
            for(int i=0; i<ss.Count;i++)
            {
                ss[i] = i + ". " + ss[i];
            }
            
            if (id == true) return sskopia;
            else return ss;

        }

        public void Wyswietl(int i)
        {

            TRIP_ALIEN T = ts[i];
            Console.WriteLine(T.trip_id + "  " + T.head + "  " + T.route_id + "  " + T.service_id);
            foreach (ODJAZD_ALIEN O in T.odjazd)
            {
                Console.WriteLine(O.stop_id + "  " + O.departure);
            }
        }
        public void WyswietlLinie()
        {
            List<string> ss = new List<string>();

            foreach (TRIP_ALIEN O in ts)
            {
                if (ss.Contains(O.route_id) == false)
                {
                    ss.Add(O.route_id);
                }

            }
            foreach (string s in ss)
            {
                Console.WriteLine(s);
            }
        }
        public List<string> Linie()
        {
            List<string> ss = new List<string>();

            foreach (TRIP_ALIEN O in ts)
            {
                if (ss.Contains(O.route_id) == false)
                {
                    ss.Add(O.route_id);
                }

            }
            ss.Sort();
            return ss;
        }
        public List<string> Kierunki(string route)
        {
            List<string> ss = new List<string>();

            foreach (TRIP_ALIEN O in ts)
            {
                if (O.route_id == route)
                {
                    if (ss.Contains(O.head) == false)
                    {
                        ss.Add(O.head);
                    }
                }
            }
            return ss;
        }

        public static List<string> Serwisy(string wybranydzien, List<Calendar> cal)
        {
            List<string> services = new List<string>();

            foreach (Calendar c in cal)
            {
                if (wybranydzien == "poniedzialek")
                {
                    if (c.monday == "1") services.Add(c.service_id);
                }
                if (wybranydzien == "wtorek")
                {
                    if (c.tuesday == "1") services.Add(c.service_id);
                }
                if (wybranydzien == "sroda")
                {
                    if (c.wednesday == "1") services.Add(c.service_id);
                }
                if (wybranydzien == "czwartek")
                {
                    if (c.thursday == "1") services.Add(c.service_id);
                }
                if (wybranydzien == "piatek")
                {
                    if (c.friday == "1") services.Add(c.service_id);
                }
                if (wybranydzien == "sobota")
                {
                    if (c.saturday == "1") services.Add(c.service_id);
                }
                if (wybranydzien == "niedziela")
                {
                    if (c.sunday == "1") services.Add(c.service_id);
                }

            }

            return services;

        }

        public class TRIP_ALIEN
        {
            public string trip_id;
            public List<ODJAZD_ALIEN> odjazd = new List<ODJAZD_ALIEN>();
            public string service_id;
            public string route_id;
            public string head;

            public TRIP_ALIEN(string t_id, string sto, string dep, string he)
            {
                trip_id = t_id;
                head = he;
                odjazd.Add(new ODJAZD_ALIEN(sto, dep));
            }

        }

        public class ODJAZD_ALIEN
        {
            public string departure;
            public string stop_id;
            public ODJAZD_ALIEN(string sto, string dep)
            {
                stop_id = sto;
                departure = dep;
            }
        }
    }
}