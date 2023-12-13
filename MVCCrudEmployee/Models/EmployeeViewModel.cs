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
        public string Empname { get; set; }
        public int Empage { get; set; }
        public string Empemail { get; set; }
        public long Empcontact { get; set; }
        public bool Isactive { get; set; }

        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
    }
}