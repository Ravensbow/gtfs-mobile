using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(RozkladForms.Droid.AndTost))]
namespace RozkladForms.Droid
{
    
    class AndTost : ITosty
    {
        public void LongTost(string mes)
        {
            Toast.MakeText(Android.App.Application.Context, mes, ToastLength.Long).Show();
        }
        public void ShorTost(string mes)
        {
            Toast.MakeText(Android.App.Application.Context, mes, ToastLength.Short).Show();
        }
    }
}