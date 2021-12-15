using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BlogApp.CustomRenderes
{
    public class GradientButtonRenderer : Button
    {
        public static readonly BindableProperty StartColorProperty = 
            BindableProperty.Create(nameof(StartColor),  // property định nghĩa
                                    typeof(Color),  // kiểu dữ liệu
                                    typeof(GradientButtonRenderer), // kiểu lớp 
                                    Color.Black); // giá trị mặc định
        public Color StartColor
        {
            get {
                return (Color)GetValue(StartColorProperty);
            }
            set {
                SetValue(StartColorProperty, value);
            }
        }

        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
           nameof(EndColor), typeof(Color), typeof(GradientButtonRenderer), Color.Black);
        public Color EndColor
        {
            get
            {
                return (Color)GetValue(EndColorProperty);
            }
            set
            {
                SetValue(EndColorProperty, value);
            }
        }

        //public static readonly BindableProperty BoderRadiusProperty =
        //    BindableProperty.Create("BoderRadius", typeof(float), typeof(GradientButtonRenderer), 0f);
        //public float BoderRadius
        //{
        //    get
        //    {
        //        return (float)GetValue(BoderRadiusProperty);
        //    }
        //    set
        //    {
        //        SetValue(BoderRadiusProperty, value);
        //    }
        //}
    
    }
}
