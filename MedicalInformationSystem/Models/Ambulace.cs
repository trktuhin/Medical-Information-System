using System.ComponentModel.DataAnnotations;

namespace MedicalInformationSystem.Models
{
    public class Ambulance
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string Area { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Work Hour")]
        public string WorkHour { get; set; }

        [Required]
        public bool IsApproved { get; set; }

    }
}