using CSITDemo.DbModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSITDemo.Models
{
    public class StudentModel
    {
        public StudentModel()
        {
            AvailableClasses = new List<SelectListItem>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter full name")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        
        [Display(Name = "Full Address")]
        public string Address { get; set; }
        
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        //[DataType(DataType.Password)]
        //[Required]
        //public string Password { get; set; }

        //[Display(Name = "Confirm Password")]
        //[Required]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Passwords do not match.")]
        //public string ConfirmPassword { get; set; }
        public int SelectedClass { get; set; }
        public string ClassName { get; set; }

        public IList<SelectListItem> AvailableClasses { get; set; }
    }
}
