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

    public class ClassStudentMetadata
    {
        [Display(Name = "Student Name")]
        public int StudentId { get; set; }
    }

    public class TestTypeMetadata
    {
        [Display(Name = "Test Type")]
        public string Name { get; set; }
    }

    public class CourseMetadata
    {
        [Display(Name = "Course Name")]
        public string Name { get; set; }
    }

    public class ModuleMetadata
    {
        [Display(Name = "Module Name")]
        public string Name { get; set; }
    }

    public class PaymentMetadata
    {
        [Display(Name ="Loan(%)")]
        public decimal InterestRate { get; set; }

        [Display(Name ="Monthly Plan")]
        public int MonthlyInterest { get; set; }
    }

    public class InvoiceMetadata
    {
        [Display(Name ="Invoice No")]
        public int Id { get; set; }
    }

    public class MarkTypeMetadata
    {
        [Display(Name ="MarkType")]
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

    [MetadataType(typeof(ClassStudentMetadata))]
    public partial class ClassStudent
    {
        public List<int?> StudentList { get; set; }
    }

    [MetadataType(typeof(TestTypeMetadata))]
    public partial class TestType { }

    [MetadataType(typeof(CourseMetadata))]
    public partial class Course { }

    [MetadataType(typeof(ModuleMetadata))]
    public partial class Module { }

    [MetadataType(typeof(PaymentMetadata))]
    public partial class Package_Course { }

    [MetadataType(typeof(InvoiceMetadata))]
    public partial class Invoice { }

    [MetadataType(typeof(MarkTypeMetadata))]
    public partial class MarkType { }
}