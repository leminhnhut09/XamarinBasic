using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinBasic.Droid.Effects;
using XamarinBasic.Effects;

[assembly:ExportEffect(typeof(MyShadowEffect), nameof(MyShadowEffect))]
namespace XamarinBasic.Droid.Effects
{
    public class MyShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Element is Button == false) return;
            var control = Control as Android.Widget.Button;
            if (control == null) return;
            try
            {
                var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
                if (effect != null)
                {
                    //shadow
                    float radius = effect.Radius;
                    float distanceX = effect.DistanceX;
                    float distanceY = effect.DistanceY;
                    Android.Graphics.Color color = effect.Color.ToAndroid();
                    control.SetShadowLayer(radius, distanceX, distanceY, color);
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