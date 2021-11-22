using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinBasic.CustomRenderers
{
    public class RoundedCornerStackView : StackLayout
    {
        #pragma warning disable CS0618 // Type or member is obsolete
        public static readonly BindableProperty RoundedCornerRadiusProperty = BindableProperty.Create<RoundedCornerStackView, double>(v => v.RoundedCornerRadius, 0);
        #pragma warning restore CS0618 // Type or member is obsolete
        public double RoundedCornerRadius
        {
            get
            {
                return (double)GetValue(RoundedCornerRadiusProperty);
            }
            set
            {
                SetValue(RoundedCornerRadiusProperty, value);
            }
        }

        #pragma warning disable CS0618 // Type or member is obsolete
        public static readonly BindableProperty BottomLeftProperty = BindableProperty.Create<RoundedCornerStackView, bool>(v => v.BottomLeft, true);
        #pragma warning restore CS0618 // Type or member is obsolete
        public bool BottomLeft
        {
            get
            {
                return (bool)GetValue(BottomLeftProperty);
            }
            set
            {
                SetValue(BottomLeftProperty, value);
            }
        }

        #pragma warning disable CS0618 // Type or member is obsolete
        public static readonly BindableProperty TopLeftProperty = BindableProperty.Create<RoundedCornerStackView, bool>(v => v.TopLeft, true);
        #pragma warning restore CS0618 // Type or member is obsolete
        public bool TopLeft
        {
            get
            {
                return (bool)GetValue(TopLeftProperty);
            }
            set
            {
                SetValue(TopLeftProperty, value);
            }
        }

        #pragma warning disable CS0618 // Type or member is obsolete
        public static readonly BindableProperty TopRightProperty = BindableProperty.Create<RoundedCornerStackView, bool>(v => v.TopRight, true);
        #pragma warning restore CS0618 // Type or member is obsolete
        public bool TopRight
        {
            get
            {
                return (bool)GetValue(TopRightProperty);
            }
            set
            {
                SetValue(TopRightProperty, value);
            }
        }

        #pragma warning disable CS0618 // Type or member is obsolete
        public static readonly BindableProperty BottomRightProperty = BindableProperty.Create<RoundedCornerStackView, bool>(v => v.BottomRight, true);
        #pragma warning restore CS0618 // Type or member is obsolete
        public bool BottomRight
        {
            get
            {
                return (bool)GetValue(BottomRightProperty);
            }
            set
            {
                SetValue(BottomRightProperty, value);
            }
        }
    }
}
