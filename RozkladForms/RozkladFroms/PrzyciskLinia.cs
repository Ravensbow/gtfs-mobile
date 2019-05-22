using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RozkladForms
{
    public class PrzyciskLinia : Label
    {
        public Routes liniaZprzyisku;

        public PrzyciskLinia(Routes ro)
        {
            liniaZprzyisku = ro;
            Text = ro.route_short_name;
            if (ro.route_text_color != null && ro.route_text_color != string.Empty) TextColor = Color.FromHex(ro.route_text_color);
            else TextColor = Color.WhiteSmoke;
            if(ro.route_color != null && ro.route_color != string.Empty) BackgroundColor = Color.FromHex(ro.route_color);
            else BackgroundColor = Color.ForestGreen;
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(PrzyciskLinia));
            HorizontalTextAlignment = TextAlignment.Center;

        }
    }
}
