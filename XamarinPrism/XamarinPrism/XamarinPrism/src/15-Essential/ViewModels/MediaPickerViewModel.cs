using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class MediaPickerViewModel : BindableBase
    {

        private DelegateCommand _onOpenStorage;
        public DelegateCommand OnOpenStorage =>
            _onOpenStorage ?? (_onOpenStorage = new DelegateCommand(HandelOpenStorage));

        private async void HandelOpenStorage()
        {
           await MediaPicker.PickPhotoAsync();
        }

        private DelegateCommand _onOpenCamera;
        public DelegateCommand OnOpenCamera =>
            _onOpenCamera ?? (_onOpenCamera = new DelegateCommand(HandleOpenCamera));

        public DelegateCommand OnOpenVideo { get; set; }
        public MediaPickerViewModel()
        {
            OnOpenVideo = new DelegateCommand(async () => await HandleVideo());
        }

        private async Task HandleVideo()
        {
            try
            {
                var photo = await MediaPicker.CaptureVideoAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        private async void HandleOpenCamera()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

    }
}
