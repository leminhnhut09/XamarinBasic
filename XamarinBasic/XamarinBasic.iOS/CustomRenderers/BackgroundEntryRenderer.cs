using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinBasic.CustomRenderers;
using XamarinBasic.iOS;
using XamarinBasic.iOS.CustomRenderers;

[assembly:ExportRenderer(typeof(FocusEntry), typeof(BackgroundEntryRenderer))]
namespace XamarinBasic.iOS.CustomRenderers
{
    public class BackgroundEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
                Control.BorderStyle = UITextBorderStyle.Line;
            }
        }
    }
}