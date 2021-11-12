using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimationsPage : ContentPage
    {
        public AnimationsPage()
        {
            InitializeComponent();
        }

        private async void RotationButtonClick(object sender, EventArgs e)
        {
            await image.RotateTo(360, 2000);
            image.Rotation = 0;
        }

        private async void RelativeButtonClick(object sender, EventArgs e)
        {
            await image.RelRotateTo(360, 2000);
        }

        private async void TranslationButtonClick(object sender, EventArgs e)
        {
            await image.TranslateTo(100, -100, 2000);
        }

        private async void FadingButtonClick(object sender, EventArgs e)
        {
            image.Opacity = 1;
            await image.FadeTo(0.3, 5000);
        }

        private async void CompoundButtonClick(object sender, EventArgs e)
        {
            await image.TranslateTo(100, -100, 1000);
            await image.TranslateTo(-100, 100, 1000);
            await image.TranslateTo(200, -100, 1000);
            await image.TranslateTo(-100, 200, 1000);
        }

        private async void CompositeButtonClick(object sender, EventArgs e)
        {
            await image.TranslateTo(100, -100, 1000);
            image.TranslateTo(-100, 100, 1000);
            await image.TranslateTo(200, -100, 1000);
            image.TranslateTo(-100, 200, 1000);
        }

        private async void EasingButtonClick(object sender, EventArgs e)
        {
            await image.TranslateTo(0, 200, 2000, (Easing)CustomEase);
            double CustomEase(double t)
            {
                return t == 0 || t == 1 ? t : (int)(5 * t) / 5.0;
            }
        }

        private void CustomAnimationButtonClick(object sender, EventArgs e)
        {
            var animation = new Animation(callback: cb => image.Rotation = cb, start: 0, end:
            360, easing: Easing.CubicInOut);
            animation.Commit(this, "RotationAnimation", 67, 5000, Easing.BounceIn,(arg1,
                arg2) => image.Rotation = 0, ()=> true);
        }
    }
}