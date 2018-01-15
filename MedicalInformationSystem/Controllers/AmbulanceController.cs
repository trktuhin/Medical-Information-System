using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MedicalInformationSystem.Models;
using MedicalInformationSystem.ViewModels;

namespace MedicalInformationSystem.Controllers
{
    public class AmbulanceController : Controller
    {
        private ApplicationDbContext _context;

        public AmbulanceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Ambulance
        [AllowAnonymous]
        public ActionResult Index(string massage)
        {
            var viewModel = new AmbulanceListViewModel
            {
                Ambulances = _context.Ambulances.Where(a => a.IsApproved),
                Massage = massage
            };

            return View(User.IsInRole(UserRoles.CanApproveAndDeleteRecord) ? "AmbulanceList" : "AmbulanceListReadOnly", viewModel);
        }

        [Authorize]
        public ActionResult NewAmbulance()
        {
            return View(new Ambulance());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAmbulance(string massage, Ambulance ambulance)
        {
            if (!ModelState.IsValid)
            {
                return View("NewAmbulance", ambulance);
            }

            if (ambulance.Id == 0)
            {
                if (User.IsInRole(UserRoles.CanApproveAndDeleteRecord))
                {
                    ambulance.IsApproved = true;
                }

                _context.Ambulances.Add(ambulance);
            }
            else
            {
                var ambulanceInDb = _context.Ambulances.SingleOrDefault(a => a.Id == ambulance.Id);
                Mapper.Map(ambulance, ambulanceInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index",new {massage = massage});
        }

        [Authorize(Roles = UserRoles.CanApproveAndDeleteRecord)]
        public ActionResult Edit(int id)
        {
            var ambulance = _context.Ambulances.SingleOrDefault(a => a.Id == id);

            return View("NewAmbulance", ambulance);
        }


        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var ambulance = _context.Ambulances.SingleOrDefault(a => a.Id == id);

            return View("Details", ambulance);
        }
    }
}