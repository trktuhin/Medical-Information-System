using System.Collections.Generic;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.ViewModels
{
    public class ListOfDoctorsViewModel
    {
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<DoctorType> DoctorTypes { get; set; }
        public string Massage { get; set; }
    }
}