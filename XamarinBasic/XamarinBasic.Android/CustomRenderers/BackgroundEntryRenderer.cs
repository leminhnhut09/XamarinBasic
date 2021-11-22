using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinBasic.CustomRenderers;
using XamarinBasic.Droid.CustomRenderers;

[assembly:ExportRenderer(typeof(FocusEntry), typeof(BackgroundEntryRenderer))]
namespace XamarinBasic.Droid.CustomRenderers
{
    public class BackgroundEntryRenderer : EntryRenderer
    {
        Android.Graphics.Color _backgroundColor = Android.Graphics.Color.White;
        Android.Graphics.Color _currentBackgroundColor;
        public BackgroundEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                _currentBackgroundColor = Android.Graphics.Color.LightGreen;
                Control.SetBackgroundColor(_currentBackgroundColor);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            try
            {
                if (e.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
                {
                    if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == _currentBackgroundColor)
                    {
                        Control.SetBackgroundColor(_backgroundColor);
                    }
                    else
                    {
                        Control.SetBackgroundColor(_currentBackgroundColor);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}