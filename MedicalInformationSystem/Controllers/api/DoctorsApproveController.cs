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
    public class DoctorsApproveController : ApiController
    {
        private ApplicationDbContext _context;

        public DoctorsApproveController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPut]
        public void ApproveDoctor(int id)
        {
            var doctorInDb = _context.Doctors.SingleOrDefault(d => d.Id == id);

            if (doctorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            doctorInDb.IsApproved = true;

            _context.SaveChanges();
        }
    }
}
