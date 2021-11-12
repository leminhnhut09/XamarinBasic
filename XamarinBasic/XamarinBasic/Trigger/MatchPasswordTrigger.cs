using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinBasic.Trigger
{
    class MatchPasswordTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            var entry = sender as Entry;
            var flag = int.TryParse(entry.Text, out int password);
            entry.BackgroundColor = flag ? Color.Default : Color.Red;
        }
    }
}
