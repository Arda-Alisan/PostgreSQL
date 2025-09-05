using Microsoft.AspNetCore.Mvc;
using HospitallApp_DBMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HospitalManagementSystem.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly StoreDbContext _context;

        public DoctorsController(StoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var doctors = _context.Doctors
            .Include(p => p.Clinic)
            .Include(p => p.Person);
            return View(doctors);
        }
    }
}