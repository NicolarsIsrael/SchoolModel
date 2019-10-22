using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolModel.Models;
using SchoolModel.Data.Contracts;
using SchoolModel.Services.Contracts;
using SchoolModel.Data.Implementations;
using SchoolModel.Services.Implementations;
using SchoolModel.Data;

namespace SchoolModel.Controllers
{
    public class HomeController : Controller
    {
        //IUnitOfWork uow;
        //IStudentService studentService;
        AppDbContext context;
        public HomeController(/*IUnitOfWork _uow,IStudentService _studentService, */AppDbContext _ctx)
        {
            //uow = _uow;
            //studentService = _studentService;
            context = _ctx;
        }

        public IActionResult Index()
        {
            ViewBag.NumberOfStudents=context.Student.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
