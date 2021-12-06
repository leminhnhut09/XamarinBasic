using Prism.AppModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class DeviceInfomationViewModel : BindableBase, IPageLifecycleAware
    {
        // Device Model (SMG-950U, iPhone10,6)
        private string _device;
        public string Device
        {
            get { return _device; }
            set { SetProperty(ref _device, value); }
        }

        // Nhà sản xuất
        private string _manufacturer;
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { SetProperty(ref _manufacturer, value); }
        }

        // Tên thiết bị
        private string _deviceName;
        public string DeviceName
        {
            get { return _deviceName; }
            set { SetProperty(ref _deviceName, value); }
        }

        // Phiên bản
        private string _version;
        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }

        // nền tảng(hệ điều hành: android, ios..)
        private string _platform;
        public string Platform
        {
            get { return _platform; }
            set { SetProperty(ref _platform, value); }
        }


        // Loại thiết bị đang chạy
        private string _idiom;
        public string Idiom
        {
            get { return _idiom; }
            set { SetProperty(ref _idiom, value); }
        }

        // Kiểm tra có chạy trên giả lập
        private string _deviceType;
        public string DeviceType
        {
            get { return _deviceType; }
            set { SetProperty(ref _deviceType, value); }
        }

        public void OnAppearing()
        {
            Device = DeviceInfo.Model;
            Manufacturer = DeviceInfo.Manufacturer;
            DeviceName = DeviceInfo.Name;
            Version = DeviceInfo.VersionString;
            Platform = DeviceInfo.Platform.ToString();
            Idiom = DeviceInfo.Idiom.ToString();
            DeviceType = DeviceInfo.DeviceType.ToString();
        }

        public void OnDisappearing()
        {
            throw new NotImplementedException();
        }
    }
}
