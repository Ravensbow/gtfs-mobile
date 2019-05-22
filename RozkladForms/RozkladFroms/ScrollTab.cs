using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace RozkladForms
{
    
    public class ScrollableTabbedPage : TabbedPage
    {
        public List<string> poniedzialek = new List<string>();
        public List<string> wtorek = new List<string>();
        public List<string> sroda = new List<string>();
        public List<string> czwartek = new List<string>();
        public List<string> piatek = new List<string>();
        public List<string> sobota = new List<string>();
        public List<string> niedziela = new List<string>();


        public  ScrollableTabbedPage(ALIEN alien,Kalendarz kal,string linia,string kierunek,string przystanek)
        {

            List<string> dni_tygodnia = new List<string>() {"Poniedzialek","Wtorek","Sroda","Czwarek","Piatek","Sobota","Niedziela" };

            poniedzialek = alien.Godziny(linia, kierunek, przystanek, "poniedzialek", kal.calendar);
            wtorek = alien.Godziny(linia, kierunek, przystanek, "wtorek", kal.calendar);
            sroda= alien.Godziny(linia, kierunek, przystanek, "sroda", kal.calendar);
            czwartek= alien.Godziny(linia, kierunek, przystanek, "czwartek", kal.calendar);
            piatek= alien.Godziny(linia, kierunek, przystanek, "piatek", kal.calendar);
            sobota= alien.Godziny(linia, kierunek, przystanek, "sobota", kal.calendar);
            niedziela= alien.Godziny(linia, kierunek, przystanek, "niedziela", kal.calendar);




            int i = 0;
            foreach (string s in dni_tygodnia)
            {
                if (i == 0)
                {
                    var navigationPage = new NavigationPage(new SchedulePageCS(poniedzialek));

                    navigationPage.Title = s;
                    Children.Add(navigationPage);
                }
                if (i == 1)
                {
                    var navigationPage = new NavigationPage(new SchedulePageCS(wtorek));

                    navigationPage.Title = s;
                    Children.Add(navigationPage);
                }
                if (i == 2)
                {
                    var navigationPage = new NavigationPage(new SchedulePageCS(sroda));

                    navigationPage.Title = s;
                    Children.Add(navigationPage);
                }
                if (i == 3)
                {
                    var navigationPage = new NavigationPage(new SchedulePageCS(czwartek));

                    navigationPage.Title = s;
                    Children.Add(navigationPage);
                }
                if (i == 4)
                {
                    var navigationPage = new NavigationPage(new SchedulePageCS(piatek));

                    navigationPage.Title = s;
                    Children.Add(navigationPage);
                }
                if (i == 5)
                {
                    var navigationPage = new NavigationPage(new SchedulePageCS(sobota));

                    navigationPage.Title = s;
                    Children.Add(navigationPage);
                }
                if (i == 6)
                {
                    var navigationPage = new NavigationPage(new SchedulePageCS(niedziela));

                    navigationPage.Title = s;
                    Children.Add(navigationPage);
                }
                i++;
            }



        }
    }

}
