using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinBasic.CustomRenderers
{
    public class MyRadioButton : View
    {
        public static readonly BindableProperty TextProperty =
                #pragma warning disable CS0618 // Type or member is obsolete
               BindableProperty.Create<MyRadioButton, string>(t => t.Text, string.Empty);
                #pragma warning restore CS0618 // Type or member is obsolete

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set
            {
                SetValue(TextProperty, value);
            }
        }


        public static readonly BindableProperty IsCheckedProperty =
                #pragma warning disable CS0618 // Type or member is obsolete
                BindableProperty.Create<MyRadioButton, bool>(t => t.IsChecked, false);
                #pragma warning restore CS0618 // Type or member is obsolete

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set
            {
                SetValue(IsCheckedProperty, value);
            }
        }

        public event EventHandler<EventArgs> CheckedChanged;
        public void OnCheckedChanged(bool value)
        {
            CheckedChanged?.Invoke(this, new CheckedChangedEventArgs() { Value = value });
        }
    }
    public class CheckedChangedEventArgs : EventArgs
    {
        public bool Value { get; set; }
    }
}
