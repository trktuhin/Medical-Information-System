using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalInformationSystem.Dtos
{
    public class SearchDto
    {
        public string Area { get; set; }
        public int? Category { get; set; }
    }
}