using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers.api
{
    public class AmbulancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AmbulancesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpDelete]
        public void DeleteAmbulance(int id)
        {
            var ambulanceInDb = _context.Ambulances.SingleOrDefault(a => a.Id == id);

            if(ambulanceInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Ambulances.Remove(ambulanceInDb);
            _context.SaveChanges();
        }
    }
}
