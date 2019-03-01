namespace ApartmentsRentalManagement1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Management.Payments")]
    public partial class Payment
    {
        public int PaymentId { get; set; }

        [StringLength(10)]
        public string ReceiptNumber { get; set; }

        [StringLength(10)]
        public string EmployeeNumber { get; set; }

        [StringLength(10)]
        public string ContractNumber { get; set; }

        [StringLength(50)]
        public string PaymentDate { get; set; }

        [StringLength(6)]
        public string Amount { get; set; }

        public string Notes { get; set; }
    }
}
