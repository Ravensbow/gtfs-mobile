using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RozkladForms
{
    public class Kierunki
    {
        
        public string wybrany_kierunek;
        public Routes linia = new Routes();
        public List<string> kierunkiList = new List<string>();


        public Kierunki(Routes rou,Komunikacja kom)
        {


            linia = rou;

            foreach (Trips T in kom.trips)
            {
                if (kierunkiList.Contains(T.trip_headsign) == false && T.route_id == linia.route_id)
                {
                    kierunkiList.Add(T.trip_headsign);
                }

            }
            int wybor =1;
            //Rozklad.Mege mege = new Rozklad.Mege(kierunkiList);
            //wybor= Convert.ToInt16(mege.Show());
            wybrany_kierunek = kierunkiList[wybor-1];
        }

    }
}
