using System.Linq;
using System.Web.Mvc;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.Controllers
{
    public class ApproveController : Controller
    {
        private ApplicationDbContext _context;

        public ApproveController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult ApproveList()
        {
            var doctors = _context.Doctors.Where(d => !d.IsApproved)
                            .ToList();

            return View("DoctorApproveList",doctors);
        }


        [HttpPost]
        public ActionResult GetList(int approveId)
        {
            switch (approveId)
            {
                case 1:
                    var doctors = _context.Doctors.Where(d => !d.IsApproved)
                                    .ToList();
                    return View("DoctorApproveList", doctors);
                case 2:
                    var hospitals = _context.Hospitals.Where(d => !d.IsApproved)
                                    .ToList();
                    return View("HospitalApproveList", hospitals);
                case 3:
                    var ambulances = _context.Ambulances.Where(d => !d.IsApproved)
                                    .ToList();
                    return View("AmbulanceApproveList", ambulances);
                case 4:
                    var pharmacies = _context.Pharmacies.Where(p => !p.IsApproved)
                                    .ToList();
                    return View("PharmacyApproveList", pharmacies);
                case 5:
                    var banks = _context.BloodBanks.Where(b => !b.IsApproved)
                                    .ToList();
                    return View("BloodBanksApproveList", banks);

                default:
                    return RedirectToAction("ApproveList", "Approve");
            }

            
        }
    }

}