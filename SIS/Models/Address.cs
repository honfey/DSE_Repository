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
    
    public partial class Address
    {
        public int Id { get; set; }
        public Nullable<int> StudentId { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    
        public virtual Student Student { get; set; }
    }
}