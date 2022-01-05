using Android.Content;
using Android.Graphics.Drawables;
using BlogApp.CustomRenderes;
using BlogApp.Droid.CustomRenderers;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(GradientButtonRenderer), typeof(AndroidGradientButtonRenderer))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace BlogApp.Droid.CustomRenderers
{
    [Obsolete]
    public class AndroidGradientButtonRenderer : ButtonRenderer
    {
        private Context _context;
        public AndroidGradientButtonRenderer(Context context) : base(context)
        {
            _context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                var caller = e.NewElement as GradientButtonRenderer;
                if (caller == null) return;
                var gradientColor = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new[] {
                    caller.StartColor.ToAndroid().ToArgb(),
                    caller.EndColor.ToAndroid().ToArgb()
                });
                gradientColor.SetCornerRadius(caller.CornerRadius.ToDevicePixels(_context));
                Control.SetBackground(gradientColor);
                var num = caller.IsEnabled ? 105f : 100f;
                Control.Elevation = num;
                Control.TranslationZ = num;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var caller = sender as GradientButtonRenderer;
            if (caller == null || Control == null) return;
            if (e.PropertyName == nameof(caller.StartColor))
            {
                var gradientColor = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new[] {
                    caller.StartColor.ToAndroid().ToArgb(),
                    caller.EndColor.ToAndroid().ToArgb()
                });
                gradientColor.SetCornerRadius(caller.CornerRadius.ToDevicePixels(_context));
                Control.SetBackground(gradientColor);
            }
        }
    }
    public static class HelperExtension
    {
        public static float ToDevicePixels(this int number, Context ctx)
        {
            var displayMetrics = ctx.Resources.DisplayMetrics;
            return (float)System.Math.Round(number * (displayMetrics.Xdpi / (float)Android.Util.DisplayMetricsDensity.Default));
        }
    }
}