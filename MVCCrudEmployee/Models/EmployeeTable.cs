//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCCrudEmployee.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeTable()
        {
            this.AddressTables = new HashSet<AddressTable>();
        }
    
        public int Empid { get; set; }
        public string Empname { get; set; }
        public int Empage { get; set; }
        public string Empemail { get; set; }
        public long Empcontact { get; set; }
        public Nullable<bool> Isactive { get; set; }
        public string Employeeid { get; set; }
        public string Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressTable> AddressTables { get; set; }
    }
}
