using System.Collections.Generic;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.ViewModels
{
    public class BloodBankListViewModel
    {
        public IEnumerable<BloodBank> BloodBanks { get; set; }
        public string Massage { get; set; }
    }
}