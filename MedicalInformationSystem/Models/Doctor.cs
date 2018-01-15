using System.ComponentModel.DataAnnotations;

namespace MedicalInformationSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Area { get; set; }

        [StringLength(50)]
        [Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }

        public DoctorType DoctorType { get; set; }

        [Display(Name = "Specialized In")]
        [Required]
        public short DoctorTypeId { get; set; }

        [Required]
        [Display(Name = "Work Hour")]
        [StringLength(50)]
        public string WorkHour { get; set; }

        public bool IsApproved { get; set; }


    }
}