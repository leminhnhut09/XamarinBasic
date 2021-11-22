using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XamarinBasic.Behaviors
{
    public class Password2VaidatorBehaviors
    {
        public static readonly BindableProperty AttachBehaviorProperty =
                    BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(Password2VaidatorBehaviors), false, propertyChanged: OnAttachBehaviorChanged);

        static void OnAttachBehaviorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Entry entry = bindable as Entry;
            if (entry == null)
            {
                return;
            }
            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }
        static void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";
            bool isValid = Regex.IsMatch(e.NewTextValue, passwordRegex);
            ((Entry)sender).BackgroundColor = isValid ? Color.Default : Color.Red;
        }
        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }
        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }
    }
}
