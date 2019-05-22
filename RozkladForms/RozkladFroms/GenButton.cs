using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RozkladForms
{
    public static class GenButton
    {
        public static Button Generuj(string tekst)
        {
            Button b1 = new Button();

            b1.Text = tekst;
            

            return b1;
        }
    }
}
