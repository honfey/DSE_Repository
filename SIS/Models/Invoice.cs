//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public string Ref { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Amount2 { get; set; }
        public Nullable<decimal> Amount3 { get; set; }
        public Nullable<decimal> GST { get; set; }
        public Nullable<decimal> GST2 { get; set; }
        public Nullable<decimal> GST3 { get; set; }
        public Nullable<decimal> GSTAmt { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> FinalTotal { get; set; }
        public string Color { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
