using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers.api
{
    public class HospitalsController : ApiController
    {
        private ApplicationDbContext _context;

        public HospitalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpDelete]
        public void DeleteHospital(int id)
        {
            var hospital = _context.Hospitals.SingleOrDefault(h => h.Id == id);

            if(hospital == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Hospitals.Remove(hospital);
            _context.SaveChanges();
        }
    }
}
