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
    
    public partial class Sibling
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public Nullable<int> HomePosition { get; set; }
        public string Occupation { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
