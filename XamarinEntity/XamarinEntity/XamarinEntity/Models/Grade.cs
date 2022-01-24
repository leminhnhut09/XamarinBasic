using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XamarinEntity.Models
{
    public class Grade : BindableBase
    {
        private int _gradeId;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeId
        {
            get { return _gradeId; }
            set { SetProperty(ref _gradeId, value); }
        }

        [Required]
        [MaxLength(5, ErrorMessage = "Maximum number of characters that can be entered is 8!")]
        public string GradeName { get; set; }

        //private string _gradeName;
        //[MaxLength(5)]
        //public string GradeName
        //{
        //    get { return _gradeName; }
        //    set { SetProperty(ref _gradeName, value); }
        //}
    }
}
