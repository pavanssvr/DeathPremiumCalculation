using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer
    {
        [Required]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = "Enter valid customer name")]
        [StringLength(100, MinimumLength = 3)]
        public string CustomerName { get; set; }

        [Range(16, 100, ErrorMessage = "Age must be between 16 between 100")]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Factor { get; set; }

        [Required]
        [Range(1000, 10000000, ErrorMessage = "Death Sum Insured value must be between 1000 and 100,00,000")]
        public int DeathSumInsured { get; set; }
    }
}
