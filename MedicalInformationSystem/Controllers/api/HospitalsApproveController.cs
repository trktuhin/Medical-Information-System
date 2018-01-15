using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers.api
{
    public class HospitalsApproveController : ApiController
    {
        private ApplicationDbContext _context;

        public HospitalsApproveController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPut]
        public void ApproveHospital(int id)
        {
            var hospitalInDb = _context.Hospitals.SingleOrDefault(d => d.Id == id);

            if (hospitalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            hospitalInDb.IsApproved = true;

            _context.SaveChanges();
        }
    }
}
