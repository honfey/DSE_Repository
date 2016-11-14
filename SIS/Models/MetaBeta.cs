using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS.Models
{
    public class CourseMetaBeta
    {
        [Display(Name = "CourseCode")]
        public string Name { get; set; }
    }

    public class PaymentMetaData
    {
        [Display(Name = "Loan(%)")]
        public decimal InterestRate { get; set; }

        [Display(Name = "MonthlyPln")]
        public int MonthlyInterest { get; set; }
    }

    [MetadataType(typeof(CourseMetaBeta))]
    public partial class Course { }

    [MetadataType(typeof(PaymentMetaData))]
    public partial class Package_Course { }
}