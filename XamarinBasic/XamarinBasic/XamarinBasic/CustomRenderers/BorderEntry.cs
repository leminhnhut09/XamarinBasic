using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace XamarinBasic.CustomRenderers
{
    public class BorderEntry : Entry
    {
        public static readonly BindableProperty BorderRadiusProperty =
            BindableProperty.Create(nameof(BorderRadius), typeof(float), typeof(BorderEntry), 0f, coerceValue: CoerceBoderRadius);

        private static object CoerceBoderRadius(BindableObject bindable, object value)
        {
            var myEntry = bindable as BorderEntry;
            float newRadius = (float)value;
            if(newRadius > 100)
            {
                newRadius = 10;
            }
            return newRadius;
        }

        public float BorderRadius {
            get
            {
                return (float)GetValue(BorderRadiusProperty);
            }
            set
            {
                SetValue(BorderRadiusProperty, value);
            }
        }
        public BorderEntry()
        {
        }
    }
}
