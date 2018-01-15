using System.Linq;
using System.Net;
using System.Web.Http;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers.api
{
    public class BloodBanksController : ApiController
    {
        private ApplicationDbContext _context;

        public BloodBanksController()
        {
             _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpDelete]
        public void DeleteBloodBank(int id)
        {
            var bank = _context.BloodBanks.SingleOrDefault(b => b.Id == id);

            if(bank == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.BloodBanks.Remove(bank);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Approve(int id)
        {
            var bank = _context.BloodBanks.SingleOrDefault(b => b.Id == id);

            if(bank == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            bank.IsApproved = true;

            _context.SaveChanges();
        }
    }
}
