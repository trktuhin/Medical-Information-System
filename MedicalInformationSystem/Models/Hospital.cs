using System.ComponentModel.DataAnnotations;

namespace MedicalInformationSystem.Models
{
    public class Hospital
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
        [StringLength(50)]
        [Display(Name = "Work Days")]
        public string WorkDays { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        public bool IsApproved { get; set; }
    }
}