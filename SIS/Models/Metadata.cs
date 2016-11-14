using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS.Models
{
    public class StudentMetadata
    {
        [Display(Name="Student Name")]
        public string Name { get; set; }
    }

    public class TestTypeMetadata
    {
        [Display(Name = "TestType")]
        public string Name { get; set; }
    }
    //public class AssignMetadata
    //{
    //    [Required]
    //    [Range(0, 100)]
    //    [Display(Name = "Assigned Hour")]
    //    public Nullable<double> HOURS { get; set; }
    //}


    [MetadataType(typeof(StudentMetadata))]
    public partial class Student { }

    [MetadataType(typeof(TestTypeMetadata))]
    public partial class TestType { }
}