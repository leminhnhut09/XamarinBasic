using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class PreferencesViewModel : BindableBase
    {
        private bool _isToggle;
        public bool IsToggle
        {
            get
            {
                return Preferences.Get("check", false);
            }
            set
            {
                Preferences.Set("check", value);
                SetProperty(ref _isToggle, value);
            }
        }
        private DelegateCommand _onSaveCommand;
        public DelegateCommand OnSaveCommand =>
            _onSaveCommand ?? (_onSaveCommand = new DelegateCommand(HandleSave));

        void HandleSave()
        {
            Preferences.Clear();
            // Xóa 1
            //Preferences.Remove("my_key");
            // Tìm theo key
            //bool hasKey = Preferences.ContainsKey("my_key");
        }
    }
}
