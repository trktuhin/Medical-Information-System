using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers.api
{
    public class DoctorsController : ApiController
    {
        private ApplicationDbContext _context;

        public DoctorsController()
        {
            _context = new ApplicationDbContext();
        }

        // DELETE: api/doctors/id
        [HttpDelete]
        public void DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == id);

            if(doctor == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}
