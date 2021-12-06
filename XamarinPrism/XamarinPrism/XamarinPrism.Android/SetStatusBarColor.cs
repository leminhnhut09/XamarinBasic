using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Speech.Tts;
using Xamarin.Forms;
using XamarinPrism.Droid;
using XamarinPrism.src._15_Essential.Services;
using Xamarin.Essentials;

[assembly: Dependency(typeof(SetStatusBarColorService))]
namespace XamarinPrism.Droid
{
    public class SetStatusBarColorService : IStatusBar
    {
        public void SetStatusBar(System.Drawing.Color color)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop) return;
            var window = ((MainActivity)Forms.Context).Window;
            window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
            var androidColor = color.ToPlatformColor();
            window.SetStatusBarColor(androidColor);
        }
    }
}