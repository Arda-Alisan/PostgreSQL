using Microsoft.AspNetCore.Mvc;
using HospitallApp_DBMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace HospitalManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly StoreDbContext _context;

        public AdminController(StoreDbContext context)
        {
            _context = context;
        }
        

        // Person CRUD Processes

        [HttpGet]
        public IActionResult PersonsCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonsCreate(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            ViewBag.personid = person.PersonId;
            if (person.doctor)
            {
                return View("DoctorsCreate");
            }
            if (person.patient)
            {
                return View("PatientsCreate");
            }

            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> PersonsUpdate(long? id)
        {
            var person = await _context.Persons.FindAsync(id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> PersonsUpdate(long id, Person person)
        {
            
            person.PersonId = id;
            try
            {
                _context.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            if (person.doctor)
            {
                return RedirectToAction("DoctorsUpdate", new{ id = person.PersonId});
            }
            if (person.patient)
            {
                return RedirectToAction("PatientsUpdate", new{ id = person.PersonId});
            }

            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> PersonsDelete(long? id)
        {
            var person = await _context.Persons.FindAsync(id);
            if(person.doctor) {
                ViewBag.Index = "DoctorsIndex";
                ViewBag.aa = id;
            }
            if(person.patient) {
                ViewBag.Index = "PatientsIndex";
            }
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> PersonsDelete( long id)
        {
            var person = await _context.Persons.FindAsync(id);
            var doctor = await _context.Doctors.FindAsync(id);
            var patient = await _context.Patients.FindAsync(id);
            Console.WriteLine( "aa");
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            
            if (person.doctor)
            {
                _context.Persons.Remove(person);
                _context.Doctors.Remove(doctor);
                return RedirectToAction("DoctorsIndex");
            }
            if (person.patient)
            {
                _context.Persons.Remove(person);
                _context.Patients.Remove(patient);
                return RedirectToAction("PatientsIndex");
            }
            return View(person);
        }


        // Doctor Admin CRUD Processes
        public IActionResult DoctorsIndex()
        {
            var doctors = _context.Doctors
            .Include(p => p.Clinic)
            .Include(p => p.Person);
            return View(doctors);
        }

        [HttpGet]
        public IActionResult DoctorsCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoctorsCreate(Doctor doctor)
        {


            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return RedirectToAction("DoctorsIndex");

            return View(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> DoctorsUpdate(long? id)
        {
            var doctor = await _context.Doctors.Include(p => p.Person).FirstOrDefaultAsync(p => p.PersonId == id);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> DoctorsUpdate(long id, Doctor doctor)
        {
            doctor.PersonId = id;
            try
            {
                _context.Update(doctor);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("DoctorsIndex");
        }

        [HttpGet]
        public async Task<IActionResult> DoctorsDelete(long? id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> DoctorsDelete([FromForm] long id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction("DoctorsIndex");
        }


        // Patient Admin CRUD Processes
        public IActionResult PatientsIndex()
        {
            var patients = _context.Patients.Include(p => p.Person);
            return View(patients);
        }

        [HttpGet]
        public IActionResult PatientsCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PatientsCreate(Patient patient)
        {

            _context.Patients.Add(patient);
            _context.SaveChanges();
            return RedirectToAction("PatientsIndex");

            return View(patient);
        }

        [HttpGet]
        public async Task<IActionResult> PatientsUpdate(long? id)
        {
            var patient = await _context.Patients.Include(p => p.Person).FirstOrDefaultAsync(p => p.PersonId == id);
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> PatientsUpdate(long id, Patient patient)
        {
            patient.PersonId = id;
            try
            {
                _context.Update(patient);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("PatientsIndex");
        }

        [HttpGet]
        public async Task<IActionResult> PatientsDelete(long? id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> PatientsDelete([FromForm] long id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction("PatientsIndex");
        }
    }
}