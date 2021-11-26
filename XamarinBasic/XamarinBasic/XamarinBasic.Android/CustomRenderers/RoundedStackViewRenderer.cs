using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinBasic.CustomRenderers;
using XamarinBasic.Droid.CustomRenderers;

[assembly:ExportRenderer(typeof(RoundedCornerStackView), typeof(RoundedStackViewRenderer))]
namespace XamarinBasic.Droid.CustomRenderers
{
    public class RoundedStackViewRenderer : VisualElementRenderer<RoundedCornerStackView>
    {
        public RoundedStackViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            if (Element == null || !Element.BottomLeft && !Element.TopLeft && !Element.TopRight && !Element.BottomRight)
                return;
            var density = Context.Resources.DisplayMetrics.Density;
            var color = Element.BackgroundColor.ToAndroid();
            SetBackgroundColor(Android.Graphics.Color.Transparent);
            var rect = new RectF(0.0f, 0.0f, Width, Height);
            var paint = new Paint(PaintFlags.AntiAlias);
            paint.Color = color;
            float radius = (float)Element.RoundedCornerRadius * density;
            canvas.DrawRoundRect(rect, radius, radius, paint);
            if (!Element.TopLeft)
            {
                var rectTopLeft = new RectF(0.0f, 0.0f, radius, radius);
                canvas.DrawRect(rectTopLeft, paint);
            }
            if (!Element.BottomLeft)
            {
                var rectBottomLeft = new RectF(0.0f, Height - radius, radius, Height);
                canvas.DrawRect(rectBottomLeft, paint);
            }
            if (!Element.TopRight)
            {
                var rectTopRight = new RectF(Width - radius, 0.0f, Width, radius);
                canvas.DrawRect(rectTopRight, paint);
            }
            if (!Element.BottomRight)
            {
                var rectBottomRight = new RectF(Width - radius, Height - radius, Width, Height);
                canvas.DrawRect(rectBottomRight, paint);
            }
        }
    }
}