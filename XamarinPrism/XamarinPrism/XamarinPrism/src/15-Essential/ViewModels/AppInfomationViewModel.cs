using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class AppInfomationViewModel : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _packageName;
        public string PackageName
        {
            get { return _packageName; }
            set { SetProperty(ref _packageName, value); }
        }

        private string _build;
        public string Build
        {
            get { return _build; }
            set { SetProperty(ref _build, value); }
        }

        private string _version;
        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }

        private string _theme;
        public string Theme
        {
            get { return _theme; }
            set { SetProperty(ref _theme, value); }
        }
        private DelegateCommand _showSettingCommand;
        public DelegateCommand ShowSettingCommand =>
            _showSettingCommand ?? (_showSettingCommand = new DelegateCommand(HandleShowSetting));

        void HandleShowSetting()
        {
            AppInfo.ShowSettingsUI();
        }
        public AppInfomationViewModel()
        {
            Name = $"Name: {AppInfo.Name}";  
            Version = $"Version Info: {AppInfo.VersionString} { AppInfo.BuildString}";
            PackageName = $"Package Name:{AppInfo.PackageName}";
            Build = $"Build: {AppInfo.BuildString}";
            Theme = $"Them: {AppInfo.RequestedTheme}";
        }
    }
}
