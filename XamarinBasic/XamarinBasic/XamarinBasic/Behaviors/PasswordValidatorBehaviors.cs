using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XamarinBasic.Behaviors
{
    public class PasswordValidatorBehaviors : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnPasswordTextChanged;
        }

        private void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";
            bool isPassword = Regex.IsMatch(e.NewTextValue, passwordRegex);
            ((Entry)sender).BackgroundColor = isPassword ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
