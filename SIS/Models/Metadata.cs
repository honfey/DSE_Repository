using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS.Models
{
    public class AttendanceMetadata
    {
        [Display(Name = "Class Start")]
        public Nullable<System.TimeSpan> MorningIn { get; set; }

        [Display(Name = "Lunch Break")]
        public Nullable<System.TimeSpan> MorningOut { get; set; }

        [Display(Name = "After Lunch")]
        public Nullable<System.TimeSpan> AfternoonIn { get; set; }

        [Display(Name = "End Class")]
        public Nullable<System.TimeSpan> AfternoonOut { get; set; }

        [Display(Name = "Date")]
        public Nullable<System.DateTime> TodayDate { get; set; }

        [Display(Name = "(M) Status")]
        public string MStatus { get; set; }

        [Display(Name = "(A) Status")]
        public string AStatus { get; set; }
    }

    public class TrainerMetadata
    {
        [Display(Name = "Trainer Name")]
        public string Name { get; set; }
    }

    public class StudentMetadata
    {
        [Display(Name = "Phone Number")]
        public string PhoneNum { get; set; }

        [Display(Name = "Other Phone Number")]
        public string OtherPhoneNum { get; set; }

        [Display(Name = "Single Parent")]
        public string SingleParent { get; set; }

        [Display(Name = "Mother Name")]
        public string MomName { get; set; }

        [Display(Name = "Mother Education")]
        public string MomEdu { get; set; }

        [Display(Name = "Mother Work Status")]
        public string MomWorkStatus { get; set; }

        [Display(Name = "Mother Job")]
        public string MomJob { get; set; }

        [Display(Name = "Mother Field Work")]
        public string MomFeildWork { get; set; }

        [Display(Name = "Mother Sector Job")]
        public string MomSectorJob { get; set; }

        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Display(Name = "IC Number")]
        public long IC { get; set; }

        [Display(Name = "Student ID")]
        public string StudentId { get; set; }

        [Display(Name = "Mom Salary")]
        public Nullable<decimal> MomSalary { get; set; }

        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Display(Name = "Father Education")]
        public string FatherEdu { get; set; }

        [Display(Name = "Father Work Status")]
        public string FatherWorkStatus { get; set; }

        [Display(Name = "Father Job")]
        public string FatherJob { get; set; }

        [Display(Name = "Father Field Work")]
        public string FatherFeildWork { get; set; }

        [Display(Name = "Father Sector Job")]
        public string FatherSectorJob { get; set; }

        [Display(Name = "Father Salary")]
        public Nullable<decimal> FatherSalary { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }

    public class SPMResultMetadata
    {
        [Display(Name = "Subject Name")]
        public Nullable<int> SubjectName { get; set; }
    }

    public class ClassStudentMetadata
    {
        [Display(Name = "Student Name")]
        public int StudentId { get; set; }

    }

    public class SiblingMetadata
    {
        [Display(Name = "Home Position")]
        public Nullable<int> HomePosition { get; set; }       
    }

    public class AddressMetadata
    {
        [Display(Name = "Street Line 1")]
        public string StreetLine1 { get; set; }
        [Display(Name = "Street Line 2")]
        public string StreetLine2 { get; set; }
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
        [Range(1, 100)]
        [Display(Name ="Loan(%)")]
        public int InterestRate { get; set; }

        [Display(Name = "MonthlyPayment/FullP")]
        public decimal MonthlyPayment { get; set; }

        [Display(Name ="Monthly Plan")]
        public int MonthlyInterest { get; set; }
    }

    public class InvoiceMetadata
    {
        [Display(Name ="Invoice No")]
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
    }

    public class MarkTypeMetadata
    {
        [Display(Name ="Mark Type")]
        public string Name { get; set; }
    }

    public class ModuleStandardMetadata
    {
        [Display(Name ="Lab Name")]
        public string LabName { get; set; }
    }
    //public class AssignMetadata
    //{
    //    [Required]
    //    [Range(0, 100)]
    //    [Display(Name = "Assigned Hour")]
    //    public Nullable<double> HOURS { get; set; }
    //}


    [MetadataType(typeof(ClassStudentMetadata))]
    public partial class ClassStudent
    {
        public List<int?> StudentList { get; set; }
    }

    [MetadataType(typeof(SiblingMetadata))]
    public partial class Sibling { }

    [MetadataType(typeof(AddressMetadata))]
    public partial class Address { }

    [MetadataType(typeof(SPMResultMetadata))]
    public partial class SPMResult { }

    [MetadataType(typeof(TestTypeMetadata))]
    public partial class TestType { }

    [MetadataType(typeof(CourseMetadata))]
    public partial class Course { }

    [MetadataType(typeof(ModuleMetadata))]
    public partial class Module { }

    [MetadataType(typeof(PaymentMetadata))]
    public partial class Package_Course
    {
        public decimal Amount { get; set; }
    }

    [MetadataType(typeof(InvoiceMetadata))]
    public partial class Invoice { }

    [MetadataType(typeof(MarkTypeMetadata))]
    public partial class MarkType { }

    [MetadataType(typeof(AttendanceMetadata))]
    public partial class Attendance { }

    [MetadataType(typeof(TrainerMetadata))]
    public partial class Trainer { }

    [MetadataType(typeof(StudentMetadata))]
    public partial class Student { }

    public partial class Student {
        public int MinV { get; set; }
        public int MaxV { get; set; }
    }
}