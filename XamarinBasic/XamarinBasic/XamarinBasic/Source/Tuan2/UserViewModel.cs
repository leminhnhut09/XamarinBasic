using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinBasic.Source.Tuan2
{
    public class UserViewModel : BindableObject, INotifyPropertyChanged
    {

        public string SelectedItemText { get; private set; }
        public ICommand OutputAgeCommand { get; set; }
        public ObservableCollection<UserModel> UserList { get; set; }

        public UserViewModel()
        {
            UserList = new ObservableCollection<UserModel>()
            {
                new UserModel("user1", 1),
                new UserModel("user2", 0),
                new UserModel("user3", 0),
            };
            OutputAgeCommand = new Command<UserModel>(HandleOutputAgeCommand);
        }

        private void HandleOutputAgeCommand(UserModel user)
        {
            SelectedItemText = string.Format("{0} is {1} years old.", user.Name, 11);
            OnPropertyChanged("SelectedItemText");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;

            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
    public class UserModel
    {
        public string Name { get; set; }
        public int Sex { get; set; }
        public UserModel(string name, int sex)
        {
            this.Name = name;
            this.Sex = sex;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}