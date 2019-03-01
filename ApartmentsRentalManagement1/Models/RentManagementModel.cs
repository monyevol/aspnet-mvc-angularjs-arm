namespace ApartmentsRentalManagement1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RentManagementModel : DbContext
    {
        public RentManagementModel()
            : base("name=RentManagementModel")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<RentContract> RentContracts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
