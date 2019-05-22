using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.Design.Widget;
using RozkladForms;
using RozkladForms.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(ScrollableTabbedPage), typeof(ScrollableTabbedPageRenderer))]
namespace RozkladForms.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class ScrollableTabbedPageRenderer : TabbedPageRenderer
    {
        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);
            var tabLayout = child as TabLayout;
            if (tabLayout != null)
            {
                tabLayout.TabMode = TabLayout.ModeScrollable;
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}