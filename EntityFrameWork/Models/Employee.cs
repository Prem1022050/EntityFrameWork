using System.ComponentModel.DataAnnotations;

namespace EntityFrameWork.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Please Enter Your Name")]
        [StringLength(100)] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Salary")]

        public long Salary { get; set; }

        [Required(ErrorMessage = "Please Enter Your Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set;}
    }
}
