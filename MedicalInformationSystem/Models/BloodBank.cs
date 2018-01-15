using System.ComponentModel.DataAnnotations;

namespace MedicalInformationSystem.Models
{
    public class BloodBank
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Phone]
        [Required]
        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string Area { get; set; }

        [Required]
        [StringLength(100)]              
        public string Address { get; set; }

        [Required]
        public bool IsApproved { get; set; }
    }
}