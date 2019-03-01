namespace ApartmentsRentalManagement1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HumanResources.Employees")]
    public partial class Employee
    {
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [StringLength(10)]
        [Display(Name = "Employee #")]
        public string EmployeeNumber { get; set; }

        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Employment Title")]
        public string EmploymentTitle { get; set; }

        public string Identification
        {
            get
            {
                return EmployeeNumber + " - " + FirstName + " " + LastName + " (" + EmploymentTitle + ")";
            }
        }
    }
}
