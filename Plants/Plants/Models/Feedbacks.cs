//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Plants.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Feedbacks
    {
        public int Feedback_id { get; set; }
        public string Feedback_text { get; set; }
        public Nullable<System.DateTime> Feedback_Date { get; set; }
        public string userId { get; set; }
        public Nullable<int> IsAccepted { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
