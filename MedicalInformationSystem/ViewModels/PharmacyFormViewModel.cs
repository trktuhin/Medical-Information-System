using System.Collections.Generic;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.ViewModels
{
    public class PharmacyFormViewModel
    {
        public IEnumerable<Pharmacy> Pharmacies { get; set; }
        public string Massage { get; set; }
    }
}