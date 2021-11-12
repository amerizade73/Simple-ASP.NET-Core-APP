using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Data.Domain
{
    public class Person
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter First Name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile.")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Address.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Gender.")]
        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Birthday.")]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
    }
}
