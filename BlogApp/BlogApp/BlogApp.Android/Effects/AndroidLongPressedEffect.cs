using Android.Views;
using BlogApp.Droid.Effects;
using BlogApp.Effects;
using System;
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


            //float xMin = Control.GetX();
            //float yMin = Control.GetY();
            //float xMax = Control.Width + xMin;
            //float yMax = Control.Height + yMin;

            //float x1 = e.Event.GetX() + xMin;
            //float y1 = e.Event.GetY() + yMin;

            float x_Mouse_Btn = e.Event.GetX();
            float y_Mouse_Btn = e.Event.GetY();
            float x_Btn_Screen = Control.GetX();
            float y_Btn_Screen = Control.GetY();
            float x_Mouse_Screen = x_Mouse_Btn + x_Btn_Screen;
            float y_Mouse_Screen = y_Mouse_Btn + y_Btn_Screen;
            float HeightBtn = Control.Height;
            float WidthBtn = Control.Width;
            if (e.Event.Action == MotionEventActions.Down)
            {
                Console.WriteLine("Ấnnnnnnnnnnnnn");
                _isLongPressed = true;
                Control.SetBackgroundColor(Android.Graphics.Color.Green);
                _timer = new Timer(HanldeCallBack, null, 2000, Timeout.Infinite);
           
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
                //Console.WriteLine("Tọa độ nhấn: (x, y): {0},{1}", x1, y1);
                //Console.WriteLine("Tọa độ control: (xMin, xMax, yMin, yMax): {0},{1}, {2},{3}", xMin, xMax, yMin, yMax);
                ////Console.WriteLine("Tọa độ button: (x1, x2, y1, y2): {0},{1},{2},{3}", 0, width, 0, height);
                //if (x1 < xMin || x1 > xMax || y1 < yMin || y1 > yMax)
                //{
                //    Console.WriteLine("Out side");
                //    Cancel();
                //}

                Console.WriteLine("x, y ({0}, {1})", x_Mouse_Btn, y_Mouse_Btn);

                if (x_Mouse_Screen > (x_Btn_Screen + WidthBtn) && y_Mouse_Screen > (y_Btn_Screen + HeightBtn) ||
                    x_Mouse_Screen < (x_Btn_Screen + WidthBtn) && y_Mouse_Screen > (y_Btn_Screen + HeightBtn) ||
                    x_Mouse_Screen > (x_Btn_Screen + WidthBtn) && y_Mouse_Screen < (y_Btn_Screen + HeightBtn) ||
                    x_Mouse_Screen < (x_Btn_Screen + WidthBtn) && y_Mouse_Screen < (y_Btn_Screen + HeightBtn))
                    Cancel();
                Control.SetBackgroundColor(Android.Graphics.Color.Purple);
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