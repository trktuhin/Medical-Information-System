using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.ViewModels
{
    public class HospitalListViewModel
    {
        public IEnumerable<Hospital> Hospitals { get; set; }
        public string Massage { get; set; }
    }
}