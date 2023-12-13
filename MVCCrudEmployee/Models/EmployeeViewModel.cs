using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCrudEmployee.Models
{
    public class EmployeeViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Empid { get; set; }

        [Required (ErrorMessage ="Name is required")]
        public string Empname { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18,100, ErrorMessage ="Age should be greater than 18")]
        public int Empage { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Enter proper email format")]
        public string Empemail { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        public long Empcontact { get; set; }
        public bool Isactive { get; set; }

        [Required(ErrorMessage = "Address line 1 is required")]
        public string Addressline1 { get; set; }

        [Required(ErrorMessage = "Address line 2 required")]
        public string Addressline2 { get; set; }
    }
}