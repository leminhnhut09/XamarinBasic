using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class FilePickerViewModel : BindableBase
    {

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { SetProperty(ref _fileName, value); }
        }
        private ImageSource _image;
        public ImageSource Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
        private DelegateCommand _onFilePickerCommand;
        public DelegateCommand OnFilePickerCommand =>
            _onFilePickerCommand ?? (_onFilePickerCommand = new DelegateCommand(ExecuteOnFilePickerCommand));

        private DelegateCommand _onMultiFilePickerCommand;
        public DelegateCommand OnMultiFilePickerCommand =>
            _onMultiFilePickerCommand ?? (_onMultiFilePickerCommand = new DelegateCommand(ExecuteOnMultiFilePickerCommand));

        async void ExecuteOnMultiFilePickerCommand()
        {

            try
            {
                var files = await FilePicker.PickMultipleAsync();
                if (files == null)
                    return;
                foreach (var file in files)
                {
                    Console.WriteLine(file.FileName);
                }
                // List
                //FileName = file.FileName;
            }
            catch (Exception ex)
            {


            }

        }

        async void ExecuteOnFilePickerCommand()
        {
            var customFileType =
               new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
               {
                { DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // or general UTType values
                { DevicePlatform.Android, new[] { "application/comics" } },
                { DevicePlatform.UWP, new[] { ".cbr", ".cbz" } },
                { DevicePlatform.Tizen, new[] { "*/*" } },
                { DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // or general UTType values
               });
            var options = new PickOptions
            {
                PickerTitle = "Please select a comic file",
                FileTypes = customFileType,
            };
            try
            {
                var file = await FilePicker.PickAsync();
                if (file == null)
                    return;
                //var img = file.OpenReadAsync();
                //Console.WriteLine("OpenReadAsync:" + img);
                FileName = file.FileName;
                if (file.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
               file.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    var stream = await file.OpenReadAsync();
                    Image = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception re)
            {
            }

        }
    }
}
