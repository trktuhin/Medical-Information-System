using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MedicalInformationSystem.Models;
using MedicalInformationSystem.ViewModels;

namespace MedicalInformationSystem.Controllers
{
    public class BloodBankController : Controller
    {
        private ApplicationDbContext _context;

        public BloodBankController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: BloodBank
        [AllowAnonymous]
        public ActionResult Index(string massage)
        {
            var viewModel = new BloodBankListViewModel
            {
                BloodBanks = _context.BloodBanks.Where(b => b.IsApproved).ToList(),
                Massage = massage
            };

            return View(User.IsInRole(UserRoles.CanApproveAndDeleteRecord) ? "BloodBankList" : "BloodBankListReadOnly", viewModel);
        }

        public ActionResult NewBank()
        {
            return View(new BloodBank());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBank(string massage,BloodBank bank)
        {
            if (!ModelState.IsValid)
            {
                return View("NewBank", bank);
            }

            if (bank.Id == 0)
            {
                if (User.IsInRole(UserRoles.CanApproveAndDeleteRecord))
                {
                    bank.IsApproved = true;
                }

                _context.BloodBanks.Add(bank);
            }
            else
            {
                var bankInDb = _context.BloodBanks.SingleOrDefault(b => b.Id == bank.Id);

                Mapper.Map(bank, bankInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new {massage = massage});
        }

        [Authorize(Roles = UserRoles.CanApproveAndDeleteRecord)]
        public ActionResult Edit(int id)
        {
            var bank = _context.BloodBanks.SingleOrDefault(b => b.Id == id);
            return View("NewBank", bank);
        }


        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var bank = _context.BloodBanks.SingleOrDefault(d => d.Id == id);

            return View(bank);
        }
    }
}