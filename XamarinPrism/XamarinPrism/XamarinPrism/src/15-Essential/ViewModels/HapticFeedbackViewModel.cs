using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class HapticFeedbackViewModel : BindableBase
    {
        private DelegateCommand _onClickCommand;
        public DelegateCommand OnClickCommand =>
            _onClickCommand ?? (_onClickCommand = new DelegateCommand(ExecuteClick));

        private DelegateCommand _onLongPressCommand;
        public DelegateCommand OnLongPressCommand =>
            _onLongPressCommand ?? (_onLongPressCommand = new DelegateCommand(ExecuteLongPress));

        private void ExecuteLongPress()
        {
            try
            {
                // Or use long press    
                HapticFeedback.Perform(HapticFeedbackType.LongPress);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private void ExecuteClick()
        {
            try
            {
                // Perform click feedback
                HapticFeedback.Perform(HapticFeedbackType.Click);

            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
