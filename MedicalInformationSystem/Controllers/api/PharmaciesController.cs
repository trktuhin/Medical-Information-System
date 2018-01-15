using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers.api
{
    public class PharmaciesController : ApiController
    {
        private ApplicationDbContext _context;

        public PharmaciesController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [System.Web.Http.HttpDelete]
        public void DeletePharmacy(int id)
        {
            var pharmacyInDb = _context.Pharmacies.SingleOrDefault(a => a.Id == id);

            if (pharmacyInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Pharmacies.Remove(pharmacyInDb);
            _context.SaveChanges();
        }

    }
}
