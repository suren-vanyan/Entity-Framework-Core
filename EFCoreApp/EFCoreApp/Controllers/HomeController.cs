using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreApp.Models;

namespace EFCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private ResortContext _resortContext;
        public HomeController(ResortContext resortContext)
        {
            _resortContext = resortContext;
        }
        public IActionResult Index()
        {
            Student student1 = new Student { Name = "Karen" };
            Student student2 = new Student { Name = "Arsen" };
            Student student3 = new Student { Name = "Grisha" };
            _resortContext.Students.AddRange(new List<Student> { student1, student2, student3 });

            Course course1 = new Course { Name = "C# OOP" };
            Course course2 = new Course { Name = "JavaScript" };
            Course course3 = new Course { Name = "TypeScript" };
            _resortContext.Courses.AddRange(new List<Course> { course1, course2, course3 });
            _resortContext.SaveChanges();

            student1.StudentCourses.Add(new StudentCourse { CourseId = course1.Id, StudentId = student1.Id });
            student1.StudentCourses.Add(new StudentCourse { CourseId = course1.Id, StudentId = student2.Id });
            student1.StudentCourses.Add(new StudentCourse { CourseId = course2.Id, StudentId = student3.Id });
          
            _resortContext.SaveChanges();
            return Json(student1);
            //return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
