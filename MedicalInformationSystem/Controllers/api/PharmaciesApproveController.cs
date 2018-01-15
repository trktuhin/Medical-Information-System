using System.Linq;
using System.Net;
using System.Web.Http;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers.api
{
    public class PharmaciesApproveController : ApiController
    {
        private ApplicationDbContext _context;

        public PharmaciesApproveController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPut]
        public void ApprovePharmacy(int id)
        {
            var pharmacyInDb = _context.Pharmacies.SingleOrDefault(p => p.Id == id);

            if (pharmacyInDb != null)
            {
                pharmacyInDb.IsApproved = true;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.SaveChanges();
        }
    }
}
