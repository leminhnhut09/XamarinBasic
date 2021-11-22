using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinBasic.CustomRenderers;
using XamarinBasic.Droid.CustomRenderers;

[assembly:ExportRenderer(typeof(BorderEntry), typeof(BoderEntryRenderer))]
namespace XamarinBasic.Droid.CustomRenderers
{
    public class BoderEntryRenderer : EntryRenderer
    {
        public BoderEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var customEntry = e.NewElement as XamarinBasic.CustomRenderers.BorderEntry;
                var gradientDrawable = new GradientDrawable();
                //lấy value từ BorderEntry và set.
                gradientDrawable.SetCornerRadius(customEntry.BorderRadius); 
                gradientDrawable.SetStroke(3, Android.Graphics.Color.Red);
                gradientDrawable.SetColor(Android.Graphics.Color.Green);
                Control.SetBackground(gradientDrawable);
                Control.Gravity = GravityFlags.CenterVertical | GravityFlags.Left;
            }
        }
    }
}