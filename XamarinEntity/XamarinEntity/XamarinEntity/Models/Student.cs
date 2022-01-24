using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XamarinEntity.Models
{
    public class Student : BindableBase
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public string Id { get; set; }

        //public string Name { get; set; }
        //public bool Sex { get; set; }
        //public DateTime BirthDay { get; set; }

        //private string _avatar;
        //public string Avatar { get; set; }
        //public int GradeId { get; set; }

        //public virtual Grade Grade { get; set; }


        private int _id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }


        private string _name;

        [Required, MaxLength(50)]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        private bool _sex;

        [Required]
        public bool Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value); }
        }

        private DateTime _birthDay;


        [Required]
        public DateTime BirthDay
        {
            get { return _birthDay; }
            set { SetProperty(ref _birthDay, value); }
        }


        private string _avatar;

        [Required]
        public string Avatar
        {
            get { return _avatar; }
            set { SetProperty(ref _avatar, value); }
        }


        public int GradeId { get; set; }

        private Grade _grade;
        public virtual Grade Grade
        {
            get { return _grade; }
            set { SetProperty(ref _grade, value); }
        }
    }
}
