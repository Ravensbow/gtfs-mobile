using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace RozkladForms
{
    internal class SchedulePageCS : ContentPage
    {
        public SchedulePageCS(List<string> godziny)
        {
            System.Diagnostics.Debug.WriteLine("WIELLOSC: " + godziny.Count);
            foreach(string s in godziny)
            System.Diagnostics.Debug.WriteLine(s);
            ListView lista = new ListView();         
            lista.ItemsSource = godziny.ToArray<string>();
            Content = lista;

        }
    }
}