using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BlogApp.Droid.Effects;
using BlogApp.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(AndroidLongPressedEffect), "LongPressedEffect")]
namespace BlogApp.Droid.Effects
{
    public class AndroidLongPressedEffect : PlatformEffect
    {
        private bool _attached;
        Android.Graphics.Color _currentColor = new Android.Graphics.Color();
        protected override void OnAttached()
        {
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.LongClick += OnLongClick;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.LongClick += OnLongClick;
                }
                _attached = true;
            }

            try
            {
                var effect = (LongPressedEffect)Element.Effects.FirstOrDefault(e => e is LongPressedEffect);
                if (effect != null)
                {
                    _currentColor = effect.Color.ToAndroid();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async void OnLongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {
            //Console.WriteLine("Invoking long click command");
            //var command = LongPressedEffect.GetCommand(Element);
            //command?.Execute(LongPressedEffect.GetCommandParameter(Element));
            Control.SetBackgroundColor(Android.Graphics.Color.Red);
            await Task.Delay(500);
            Control.SetBackgroundColor(_currentColor);
        }
        protected override void OnDetached()
        {
            if (_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.LongClick -= OnLongClick;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.LongClick -= OnLongClick;
                }
                _attached = false;
            }
        }
    }
}