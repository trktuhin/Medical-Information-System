using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.ViewModels
{
    public class HospitalDetailsViewModel
    {
        public Hospital Hospital { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Ambulance> Ambulances { get; set; }
    }
}