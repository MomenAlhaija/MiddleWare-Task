//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task1_BDO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tasks()
        {
            this.Timesheets = new HashSet<Timesheets>();
        }
    
        public int Task_Id { get; set; }
        public int Project_Id { get; set; }
        public string Task_Name { get; set; }
        public string Task_Description { get; set; }
        public Nullable<System.TimeSpan> Start_Date { get; set; }
        public Nullable<System.TimeSpan> End_Data { get; set; }
        public Nullable<int> Task_Status { get; set; }
        public string Employee_Id { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Projects Projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timesheets> Timesheets { get; set; }
    }
}
