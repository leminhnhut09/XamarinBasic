using Prism;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamarinPrism.src._09_TabbedPage.ViewModels
{
    public class TabBViewModel
    {
        public ObservableCollection<string> Collection { get; set; }

        public TabBViewModel()
        {
            Collection = new ObservableCollection<string>(new List<string>
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "k", "L", "M", "N", "O", "P", "I", "Q",
                "A", "B", "C", "D", "E", "F", "G", "H", "k", "L", "M", "N", "O", "P", "I", "Q",
                "A", "B", "C", "D", "E", "F", "G", "H", "k", "L", "M", "N", "O", "P", "I", "Q",
                "A", "B", "C", "D", "E", "F", "G", "H", "k", "L", "M", "N", "O", "P", "I", "Q",
                "A", "B", "C", "D", "E", "F", "G", "H", "k", "L", "M", "N", "O", "P", "I", "Q",
                "A", "B", "C", "D", "E", "F", "G", "H", "k", "L", "M", "N", "O", "P", "I", "Q",
                "A", "B", "C", "D", "E", "F", "G", "H", "k", "L", "M", "N", "O", "P", "I", "Q",
                "A", "B", "C", "D", "E", "F", "G", "H", "k", "L", "M", "N", "O", "P", "I", "Q"
            });
        }

    }
}
