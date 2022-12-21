using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDataWebApi.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Name Sholud be less than 50 characters")]
        public string Name { get; set; }

        [Range(18,65,ErrorMessage ="Age greater than 18 and less than or equal to 65")]
        public int Age { get; set; }

        public string JobTitle { get; set; }

        public string Department { get; set; }

        public string DateOfJoining { get; set; }

        public double Salary { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
