using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class FlaskLightViewModel
    {
        private DelegateCommand _onFlaskCommand;
        public DelegateCommand OnFlaskCommand =>
            _onFlaskCommand ?? (_onFlaskCommand = new DelegateCommand(ExecuteOnFlask));

        private DelegateCommand _offFlaskCommand;
        public DelegateCommand OffFlaskCommand =>
            _offFlaskCommand ?? (_offFlaskCommand = new DelegateCommand(ExecuteOffFlask));

        async void ExecuteOnFlask()
        {
            try
            {
                await Flashlight.TurnOnAsync();
            }
            catch (Exception)
            {


            }
           
        }

        async void ExecuteOffFlask()
        {
            try
            {
                await Flashlight.TurnOffAsync();
            }
            catch (Exception)
            {
            }
        }
    }
}
