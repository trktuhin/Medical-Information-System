using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.ViewModels
{
    public class NewDoctorViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<DoctorType> DoctorTypes { get; set; }
    }
}