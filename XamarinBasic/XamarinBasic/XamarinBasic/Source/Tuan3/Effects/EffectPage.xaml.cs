using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBasic.CustomRenderers;

namespace XamarinBasic.Source.Tuan3.Effects
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EffectPage : ContentPage
    {
        public EffectPage()
        {
            InitializeComponent();
            stackLayout.Children.Add(new BorderEntry());

            effectEntry.Effects.Add(Effect.Resolve("Xamarin.MyFocusEffect"));
            if (effectEntry.Effects.Contains(Effect.Resolve("Xamarin.MyFocusEffect")))
            {
                Console.WriteLine("Tim thayyyyyyyyyyyyy MyFocusEffect");
            }
            else
            {
                Console.WriteLine("Khong tim thayyyyyyyyyyyyy MyFocusEffect");
            }
            Console.WriteLine("aa " + effectEntry.Effects.FirstOrDefault().ToString());
            Console.WriteLine("bb" + Effect.Resolve("Xamarin.MyFocusEffect"));
        }
    }
}