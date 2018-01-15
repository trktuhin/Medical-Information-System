using System;
using System.Linq;
using System.Web.Mvc;
using MedicalInformationSystem.Models;
using MedicalInformationSystem.ViewModels;
using System.Data.Entity;
using AutoMapper;
using MedicalInformationSystem.Dtos;

namespace MedicalInformationSystem.Controllers
{
    
    public class DoctorController : Controller
    {
        private ApplicationDbContext _context;

        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Doctor
        [AllowAnonymous]
        public ActionResult Index(string massage)
        {
            var viewModel = new ListOfDoctorsViewModel
            {
                Doctors = _context.Doctors.Include(d => d.DoctorType).Where(d => d.IsApproved),
                DoctorTypes = _context.DoctorTypes.ToList(),
                Massage = massage
            };

            return View(User.IsInRole(UserRoles.CanApproveAndDeleteRecord) ? "ListOfDoctors" : "ListOfDoctorsReadOnly", viewModel);
        }

        [Authorize]
        public ActionResult NewDoctor()
        {
            var viewModel = new NewDoctorViewModel
            {
                Doctor = new Doctor(),
                DoctorTypes = _context.DoctorTypes.ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDoctor(Doctor doctor, string massage)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewDoctorViewModel
                {
                    Doctor = doctor,
                    DoctorTypes = _context.DoctorTypes.ToList()
                };

                return View("NewDoctor", viewModel);
            }

            if (doctor.Id == 0)
            {
                if (User.IsInRole(UserRoles.CanApproveAndDeleteRecord))
                {

                    doctor.IsApproved = true;
                    _context.Doctors.Add(doctor);
                }
                else
                {
                    doctor.IsApproved = false;
                    _context.Doctors.Add(doctor);
                }
            }
            else
            {
                var doctorInDB = _context.Doctors.SingleOrDefault(d => d.Id == doctor.Id);

                Mapper.Map(doctor, doctorInDB);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", new { massage = massage });
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Search(SearchDto search)
        {
            ListOfDoctorsViewModel viewModel;

            if (search.Area == null && search.Category == null)
            {
                viewModel = new ListOfDoctorsViewModel
                {
                    Doctors = _context.Doctors.Include(d => d.DoctorType).Where(d => d.IsApproved),
                    DoctorTypes = _context.DoctorTypes.ToList()
                };

            }
            else if (search.Area == null)
            {
                viewModel = new ListOfDoctorsViewModel
                {
                    Doctors = _context.Doctors.Include(d => d.DoctorType).Where(d => d.IsApproved && d.DoctorTypeId == search.Category),
                    DoctorTypes = _context.DoctorTypes.ToList()
                };
            }
            else if(search.Category == null)
            {
                viewModel = new ListOfDoctorsViewModel
                {
                    Doctors = _context.Doctors.Include(d => d.DoctorType).Where(d => d.IsApproved && d.Area == search.Area),
                    DoctorTypes = _context.DoctorTypes.ToList()
                };
            }
            else
            {
                viewModel = new ListOfDoctorsViewModel
                {
                    Doctors = _context.Doctors.Include(d => d.DoctorType).Where(d => d.IsApproved && (d.Area == search.Area && d.DoctorTypeId == search.Category)),
                    DoctorTypes = _context.DoctorTypes.ToList()
                };
            }

            return View(User.IsInRole(UserRoles.CanApproveAndDeleteRecord) ? "ListOfDoctors" : "ListOfDoctorsReadOnly", viewModel);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var doctor = _context.Doctors.Include(d => d.DoctorType).SingleOrDefault(d => d.Id == id);

            return View(doctor);
        }

        [Authorize(Roles = UserRoles.CanApproveAndDeleteRecord)]
        public ActionResult Edit(int id)
        {
            var viewModel = new NewDoctorViewModel
            {
                Doctor = _context.Doctors.SingleOrDefault(d => d.Id == id),
                DoctorTypes = _context.DoctorTypes.ToList()
            };

            return View("NewDoctor", viewModel);
        }
    }
}