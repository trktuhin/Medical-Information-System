using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MedicalInformationSystem.Models;
using MedicalInformationSystem.ViewModels;
using System.Data.Entity;

namespace MedicalInformationSystem.Controllers
{
    public class HospitalController : Controller
    {
        private ApplicationDbContext _context;

        public HospitalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Hospital
        [AllowAnonymous]
        public ActionResult Index(string massage)
        {
            var viewModel = new HospitalListViewModel
            {
                Hospitals = _context.Hospitals.Where(h => h.IsApproved),
                Massage = massage
            };

            return View((User.IsInRole(UserRoles.CanApproveAndDeleteRecord)) ? "HospitalList" : "HospitalListReadOnly", viewModel);
        }

        [Authorize]
        public ActionResult NewHospital()
        {
            return View(new Hospital());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveHospital(string massage, Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return View("NewHospital", hospital);
            }

            if (hospital.Id == 0)
            {
                if (User.IsInRole(UserRoles.CanApproveAndDeleteRecord))
                {
                    hospital.IsApproved = true;
                }

                _context.Hospitals.Add(hospital);
            }
            else
            {
                var hospitalInDb = _context.Hospitals.SingleOrDefault(h => h.Id == hospital.Id);
                Mapper.Map(hospital, hospitalInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new {massage = massage});
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var hospital = _context.Hospitals.SingleOrDefault(h => h.Id == id);
            var viewModel = new HospitalDetailsViewModel
            {
                Hospital = hospital,
                Doctors = _context.Doctors.Include(d => d.DoctorType).Where(d => d.HospitalName == hospital.Name).ToList(),
                Ambulances = _context.Ambulances.Where(a => a.HospitalName == hospital.Name)
            };

            return View(viewModel);
        }

        [Authorize(Roles = UserRoles.CanApproveAndDeleteRecord)]
        public ActionResult Edit(int id)
        {
            var hospital = _context.Hospitals.SingleOrDefault(h => h.Id == id);

            return View("NewHospital", hospital);
        }
    }
}