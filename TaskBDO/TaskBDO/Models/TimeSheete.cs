//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskBDO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeSheete
    {
        public int Sheet_Id { get; set; }
        public int Task_Id { get; set; }
        public double Hours_Worked { get; set; }
    
        public virtual Tasks Tasks { get; set; }
    }
}
