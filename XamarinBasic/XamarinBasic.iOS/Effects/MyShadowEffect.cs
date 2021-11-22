using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinBasic.Effects;
using XamarinBasic.iOS.Effects;

[assembly:ExportEffect(typeof(MyShadowEffect), nameof(MyShadowEffect))]
namespace XamarinBasic.iOS.Effects
{
    public class MyShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Element is Button == false) return; 
            try
            {
                var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
                if (effect != null)
                {
                    Control.Layer.CornerRadius = effect.Radius;
                    Control.Layer.ShadowColor = effect.Color.ToCGColor();
                    Control.Layer.ShadowOffset = new CGSize(effect.DistanceX, effect.DistanceY);
                    Control.Layer.ShadowOpacity = 1.0f;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override void OnDetached()
        {

        }
    }
}