using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HospitallApp_DBMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitallApp_DBMS.Controllers;

public class HomeController : Controller
{

    private readonly StoreDbContext _context;

        public HomeController(StoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(){
        return View();      
    }




    [HttpGet]       
    public ActionResult SearchByProductName(){
        return View();      
    }

    [HttpPost]
    public ActionResult SearchByProductName(string name){
        //SELECT * FROM Products WHERE Name LIKE '%name%' ORDER BY Name
        var doctors = _context.Doctors.Include(p => p.Person).Where(p => p.Person.Name.ToLower().Contains(name.ToLower())).OrderBy(p => p.Person.Name); 

        return View("~/Views/Home/Details.cshtml", doctors);      
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    
}
