using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan3.GesturesRegconizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GesturesPageThree : ContentPage
    {
        public GesturesPageThree()
        {
            InitializeComponent();
        }

        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    // Handle the swipe
                    Debug.WriteLine("Left");
                    break;
                case SwipeDirection.Right:
                    // Handle the swipe
                    Debug.WriteLine("Right");
                    break;
                case SwipeDirection.Up:
                    // Handle the swipe
                    Debug.WriteLine("Top");
                    break;
                case SwipeDirection.Down:
                    // Handle the swipe
                    Debug.WriteLine("Bottom");
                    break;
            }
        }
    }
}