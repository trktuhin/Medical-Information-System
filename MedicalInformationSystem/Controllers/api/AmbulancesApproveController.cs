using System.Linq;
using System.Net;
using System.Web.Http;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers.api
{
    public class AmbulancesApproveController : ApiController
    {
        private ApplicationDbContext _context;

        public AmbulancesApproveController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPut]
        public void ApproveAmbulance(int id)
        {
            var ambulance = _context.Ambulances.SingleOrDefault(a => a.Id == id);

            if(ambulance == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ambulance.IsApproved = true;

            _context.SaveChanges();
        }
    }
}
