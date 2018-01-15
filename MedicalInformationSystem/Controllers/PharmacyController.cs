using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MedicalInformationSystem.Models;
using MedicalInformationSystem.ViewModels;

namespace MedicalInformationSystem.Controllers
{
    public class PharmacyController : Controller
    {
        private ApplicationDbContext _context;

        public PharmacyController()
        {
            _context = ApplicationDbContext.Create();
        }

        // GET: Pharmacy
        [AllowAnonymous]
        public ActionResult Index(string massage)
        {
            var viewModel = new PharmacyFormViewModel
            {
                Pharmacies = _context.Pharmacies.Where(p => p.IsApproved),
                Massage = massage
            };

            return View(User.IsInRole(UserRoles.CanApproveAndDeleteRecord) ? "PharmacyList" : "PharmacyListReadOnly", viewModel);
        }


        
        public ActionResult NewPharmacy()
        {
            return View(new Pharmacy());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePharmacy(string massage, Pharmacy pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return View("NewPharmacy", pharmacy);
            }

            if (pharmacy.Id == 0)
            {
                if (User.IsInRole(UserRoles.CanApproveAndDeleteRecord))
                {
                    pharmacy.IsApproved = true;
                }

                _context.Pharmacies.Add(pharmacy);
            }
            else
            {
                var pharmacyInDb = _context.Pharmacies.SingleOrDefault(p => p.Id == pharmacy.Id);
                Mapper.Map(pharmacy, pharmacyInDb);

            }

            _context.SaveChanges();

            return RedirectToAction("Index", new {massage = massage});
        }

        [Authorize(Roles = UserRoles.CanApproveAndDeleteRecord)]
        public ActionResult Edit(int id)
        {
            var pharmacy = _context.Pharmacies.SingleOrDefault(p => p.Id == id);

            return View("NewPharmacy", pharmacy);
        }


        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var pharmacyInDb = _context.Pharmacies.SingleOrDefault(p => p.Id == id);

            return View(pharmacyInDb);
        }
    }
}