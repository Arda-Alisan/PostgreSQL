using Microsoft.AspNetCore.Mvc;
using HospitallApp_DBMS.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Controllers
{
    public class PatientsController : Controller
    {
        private readonly StoreDbContext _context;

        public PatientsController(StoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
             var patients = _context.Patients.Include(p => p.Person);
            return View(patients);
        }
    }
}
