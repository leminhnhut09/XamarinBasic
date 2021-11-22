using Android.Graphics.Drawables;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinBasic.Droid.Effects;

[assembly:ExportEffect(typeof(MyBoderEffect), nameof(MyBoderEffect))]
namespace XamarinBasic.Droid.Effects
{
    public class MyBoderEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control != null)
            {
                var roundableShape = new GradientDrawable();
                //roundableShape.SetShape(ShapeType.Rectangle);
                roundableShape.SetStroke(0, Android.Graphics.Color.Transparent);
                //roundableShape.SetCornerRadius(30);
                Control.SetBackground(roundableShape);
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }

        protected override void OnDetached()
        {
                
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
        }
    }
}