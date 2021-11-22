using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBasic.Source.Tuan3.BindableProperty
{
    public class BindableViewModel
    {
        public float BorderRadius { get; set; }
        public float Rotation { get; set; }
        public string Animation { get; set; }

        public Student student { get; set; }
        public BindableViewModel()
        {
            BorderRadius = 100;
            Rotation = 180;
            Animation = null;
            student = new Student()
            {
                Name = "Nguyen A",
                Gender = 0
            };
        }

        public class Student
        {
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private int _gender;

            public int Gender
            {
                get { return _gender; }
                set { _gender = value; }
            }


        }
    }
}
