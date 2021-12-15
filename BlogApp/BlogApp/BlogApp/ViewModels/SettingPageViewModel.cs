using BlogApp.Helpers;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace BlogApp.ViewModels
{
    public class SettingPageViewModel : BindableBase, IPageLifecycleAware
    {
        private int _theme = 0;
        public int Theme
        {
            get { return _theme; }
            set { SetProperty(ref _theme, value); }
        }

        private string _groupName = "ThemeGroup";
        public string GroupName
        {
            get { return _groupName; }
            set { SetProperty(ref _groupName, value); }
        }

        private DelegateCommand<string> _onChangedThemeCommand;
        public DelegateCommand<string> OnChangedThemeCommand =>
            _onChangedThemeCommand ?? (_onChangedThemeCommand = new DelegateCommand<string>(ExecuteChangedTheme));

        private void ExecuteChangedTheme(string theme)
        {
            if (theme.Equals("light"))
            {
                Theme = 1;
            }
            else if (theme.Equals("dark"))
            {
                Theme = 2;
            }
            else
                Theme = 0;
            TheTheme.SetTheme(Theme);
            Preferences.Set(ContainsKey.ThemeKey, Theme);
        }

        public void OnAppearing()
        {
            Theme = Preferences.Get("theme", 0);
            TheTheme.SetTheme(Theme);
        }

        public void OnDisappearing()
        {
            
        }
    }
}
