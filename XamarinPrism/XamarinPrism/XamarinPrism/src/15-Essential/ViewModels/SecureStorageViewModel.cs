using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class SecureStorageViewModel : BindableBase, IPageLifecycleAware
    {
        private string _user;
        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private DelegateCommand _onSavePreferenceCommand;
        public DelegateCommand OnSavePreferenceCommand =>
            _onSavePreferenceCommand ?? (_onSavePreferenceCommand = new DelegateCommand(HandleSavePreference));

        private DelegateCommand _onRemovePreferenceCommand;
        public DelegateCommand OnRemovePreferenceCommand =>
            _onRemovePreferenceCommand ?? (_onRemovePreferenceCommand = new DelegateCommand(HandleRemovePreference));

        void HandleRemovePreference()
        {
            try
            {
                //SecureStorage.Remove("user");
               SecureStorage.RemoveAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        async void HandleSavePreference()
        {
            try
            {
               await SecureStorage.SetAsync("user", User);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async void OnAppearing()
        {
            try
            {
                var result = await SecureStorage.GetAsync("user");
                User = result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void OnDisappearing()
        {
            
        }
    }
}
