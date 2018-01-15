using System.Collections.Generic;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.ViewModels
{
    public class AmbulanceListViewModel
    {
        public IEnumerable<Ambulance> Ambulances { get; set; }
        public string Massage { get; set; }
    }
}