using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MedicalInformationSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorType> DoctorTypes { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}