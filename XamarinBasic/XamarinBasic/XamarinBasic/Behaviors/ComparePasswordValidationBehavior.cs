using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinBasic.Behaviors
{
    public class ComparePasswordValidationBehavior : Behavior<Entry>
    {
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public static BindableProperty TextProperty = 
            BindableProperty.Create<ComparePasswordValidationBehavior, string>(tc => tc.Text, string.Empty, BindingMode.TwoWay);
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += HandleTextChanged;
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = e.NewTextValue == Text;
            ((Entry)sender).BackgroundColor = isValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= HandleTextChanged;
        }
    }
}
