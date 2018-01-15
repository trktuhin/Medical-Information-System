using System.ComponentModel.DataAnnotations;

namespace MedicalInformationSystem.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Area { get; set; }

        [Required]
        public bool IsApproved { get; set; }

    }
}