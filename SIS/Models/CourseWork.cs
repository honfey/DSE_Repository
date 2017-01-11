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
    
    public partial class CourseWork
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseWork()
        {
            this.Images = new HashSet<Image>();
            this.ReportCards = new HashSet<ReportCard>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ClassStudentId { get; set; }
        public Nullable<int> Course_ModuleId { get; set; }
        public Nullable<int> TestTypeId { get; set; }
        public Nullable<int> ModuleStandardId { get; set; }
        public Nullable<int> Marks { get; set; }
        public string Status { get; set; }
        public Nullable<int> Total1 { get; set; }
        public Nullable<int> Total2 { get; set; }
        public Nullable<int> Total3 { get; set; }
        public Nullable<int> Total4 { get; set; }
    
        public virtual ClassStudent ClassStudent { get; set; }
        public virtual Course_Module Course_Module { get; set; }
        public virtual ModuleStandard ModuleStandard { get; set; }
        public virtual TestType TestType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportCard> ReportCards { get; set; }
    }
}
