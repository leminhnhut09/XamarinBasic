using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using BlogApp.Droid.Effects;
using BlogApp.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(AndroidLongPressedEffect), nameof(LongPressedEffect))]
namespace BlogApp.Droid.Effects
{
    public class AndroidLongPressedEffect : PlatformEffect
    {
        private bool _attached;
        private Timer _timer;
        private bool _isLongPressed;
        private Android.Graphics.Rect _rectf;

        protected override void OnAttached()
        {
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.Touch += OnTouch;
                }
                else
                {
                    Container.Touch += OnTouch;
                }
                _attached = true;
            }
        }

        private void OnTouch(object sender, Android.Views.View.TouchEventArgs e)
        {
            float x1 = e.Event.GetX();
            float y1 = e.Event.GetY();
            float x = Control.GetX();
            float y = Control.GetY();
            float width = Control.Width;
            float height = Control.Height;
            Android.Views.View view = Control as Android.Views.View;
            if (e.Event.Action == MotionEventActions.Down)
            {
                Console.WriteLine("Ấnnnnnnnnnnnnn");
                _isLongPressed = true;
                Control.SetBackgroundColor(Android.Graphics.Color.Green);
                _timer = new Timer(HanldeCallBack, null, 5000, Timeout.Infinite);

                _rectf = new Android.Graphics.Rect(view.Left, view.Top, view.Right, view.Bottom);
                Console.WriteLine("x,y,w,h: ({0},{1},{2},{3})", view.Left, view.Top, view.Right, view.Bottom);
            }
            else if (e.Event.Action == MotionEventActions.Up)
            {
                if (!_isLongPressed) return;
                Console.WriteLine("Thảaaaaaaaaaaaaaaaaa");
                Cancel();
                Control.SetBackgroundColor(Android.Graphics.Color.Purple);
                _isLongPressed = false;
            }
            else if (e.Event.Action == MotionEventActions.Move)
            {
                Console.WriteLine("Tọa độ nhấn: (x, y): {0},{1}", x1 + x, y1 + y);
                Console.WriteLine("Tọa độ button: (x1, x2, y1, y2): {0},{1},{2},{3}", x, x + width, y, y + height);


                if (x1 + x < x || x1 + x > x + width || y1 + y < 0 || y1 + y > y + height)
                {
                    Console.WriteLine("Out Side");
                }
            }
            else if (e.Event.Action == MotionEventActions.Outside)
            {
                Console.WriteLine("Outsideeeeeeeeeeee");
            }
        }
        private void Cancel()
        {
            if (_timer == null)
            {
                return;
            }
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Dispose();
            _timer = null;
            Console.WriteLine("Timer disposed...");
        }

        private void HanldeCallBack(object state)
        {
            var command = LongPressedEffect.GetCommand(Element);
            command?.Execute(LongPressedEffect.GetCommandParameter(Element));
        }

        protected override void OnDetached()
        {
            if (_attached)
            {
                if (Control != null)
                {
                    Control.Touch -= OnTouch;
                }
                else
                {
                    Container.Touch -= OnTouch;
                }
                _attached = false;
            }
        }
    }
}