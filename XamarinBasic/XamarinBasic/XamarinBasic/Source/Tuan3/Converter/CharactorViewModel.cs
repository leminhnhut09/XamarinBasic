using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinBasic.Source.Tuan3.Converter
{
    public class CharactorViewModel
    {
        public ObservableCollection<Charactor> Collection { get; set; }
        public CharactorViewModel()
        {
            Collection = new ObservableCollection<Charactor>(Charactor.GetListCharactor());
        }
    }

    public class Charactor : INotifyPropertyChanged
    {
        private string _name;
        private string _avatar;
        private int _gender;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(Name);
            }
        }

        public string Avatar
        {
            get
            {
                return _avatar;
            }
            set
            {
                _avatar = value;
                OnPropertyChanged(Avatar);
            }
        }

        public int Gender 
        {
            get {
              return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public Charactor(string name, string src, int gender)
        {
            Name = name;
            Avatar = src;
            Gender = gender;
        }

        public static List<Charactor> GetListCharactor()
        {
            List<Charactor> listCharactor = new List<Charactor>()
            {
                new Charactor("Luffy", "control.png", 0),
                new Charactor("Nami", "check.png", 1),
                new Charactor("Chopper", "layout.png", 0),
                new Charactor("Sabo", "control.png", 0),
                new Charactor("Zoro", "check.png", 0),
            };
            return listCharactor;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
