using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan3.Effects
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EffectPage : ContentPage
    {
        public EffectPage()
        {
            InitializeComponent();
            effectEntry.Effects.Add(Effect.Resolve("Xamarin.MyFocusEffect"));
        }
    }
}