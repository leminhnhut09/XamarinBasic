using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinBasic.Droid.Effects;

[assembly: ResolutionGroupName("Xamarin")]
[assembly:ExportEffect(typeof(MyFocusEffect), nameof(MyFocusEffect))]
namespace XamarinBasic.Droid.Effects
{
    public class MyFocusEffect : PlatformEffect
    {
        Android.Graphics.Color _oldBackgroundColor = new Android.Graphics.Color(0, 0, 0, 0);
        Android.Graphics.Color _backgroundColor;
        protected override void OnAttached()
        {
            try
            {
                _backgroundColor = Android.Graphics.Color.Green;
                Control.SetBackgroundColor(_backgroundColor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override void OnDetached()
        {
        }
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
                {
                    if ((Control.Background as Android.Graphics.Drawables.ColorDrawable).Color == _oldBackgroundColor)
                    {
                        Control.SetBackgroundColor(_backgroundColor);
                    }
                    else
                    {
                        Control.SetBackgroundColor(_oldBackgroundColor);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}