using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinBasic.CustomRenderers;
using XamarinBasic.iOS.CustomRenderers;

[assembly:ExportRenderer(typeof(BorderEntry), typeof(BoderEntryRenderer))]
namespace XamarinBasic.iOS.CustomRenderers
{
    public class BoderEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var customEntry = e.NewElement as BorderEntry;
                if (customEntry == null) return;
                //lấy value từ BorderEntry và set.
                Control.Layer.CornerRadius = customEntry.BorderRadius;
                Control.Layer.BorderWidth = 3;
                Control.Layer.BorderColor = Color.BlueViolet.ToCGColor();
                Control.TextAlignment = UITextAlignment.Right;
            }
        }
    }
}