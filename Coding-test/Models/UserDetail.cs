using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Coding_test.Models
{
    public class UserDetail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must be required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender must be Selected")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone Number must be required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email must be required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address must be required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Nationality must be required")]

        public string Nationality { get; set; }

        [Required(ErrorMessage = "Date of Birth must be picked")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Education Background")]

        [Required(ErrorMessage = "Education Background must be required")]
        public string EducationBackground { get; set; }

        [Display(Name = "Preferred Mode of Contact")]
        [Required(ErrorMessage = "Preferred must be selected")]
        public string PreferredModeOfContact { get; set; }
    }
}
