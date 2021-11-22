using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinBasic.iOS.Effects;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(MyFocusEffect), nameof(MyFocusEffect))]
namespace XamarinBasic.iOS.Effects
{
    public class MyFocusEffect : PlatformEffect
    {
        UIColor _backgroundColor;

        protected override void OnAttached()
        {
            try
            {
                Control.BackgroundColor = _backgroundColor = UIColor.FromRGB(123, 456, 789);
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
            if (args.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
            {
                try
                {
                    if (Control.BackgroundColor == _backgroundColor)
                    {
                        Control.BackgroundColor = UIColor.White;
                    }
                    else
                    {
                        Control.BackgroundColor = _backgroundColor;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}