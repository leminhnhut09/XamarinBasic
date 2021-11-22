using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinBasic.CustomRenderers;
using XamarinBasic.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(MyRadioButton), typeof(XamarinBasic.Droid.CustomRenderers.RadioButtonRenderer))]
namespace XamarinBasic.Droid.CustomRenderers
{
    public class RadioButtonRenderer : ViewRenderer<MyRadioButton, Android.Widget.RadioButton>
    {
        public RadioButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MyRadioButton> e)
        {
            base.OnElementChanged(e);
            // plat form
            if(e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= ElementPropertyChanged;
            }
            // plat form
            if(Control == null)
            {
                var radioButton = new Android.Widget.RadioButton(Context);
                SetNativeControl(radioButton);
            }
            // set value
            Control.Text = e.NewElement.Text;
            Control.TextSize = 20;
            Control.Checked = e.NewElement.IsChecked;
            Control.CheckedChange += OnCheckedChange;
            Element.PropertyChanged += ElementPropertyChanged;
        }

        private void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            var view = Element;
            if (view != null)
            {
                view.IsChecked = e.IsChecked;
                view.OnCheckedChanged(e.IsChecked);
            }
        }

        private new void ElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.IsChecked;
                    break;

                case "Text":
                    Control.Text = Element.Text;
                    break;

                default:
                    break;
            }
        }
    }
}