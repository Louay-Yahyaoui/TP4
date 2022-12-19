using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UniversityContext uni = UniversityContext.getInstance();
            List<Student> s = uni.Student.ToList();

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
        [Route("courses")]
        public IActionResult Courses()
        {

            UnitOfWork unit = new UnitOfWork();
            
            List<string> courses
                        = new List<string>();
            foreach (Student s in unit.Students.GetAll())
            {
                if (!courses.Contains(s.course))
                    courses.Add(s.course);
            }

            return View(courses);
        }
        [Route("Students/{X}")]
        public IActionResult Students(string X)
        {
            UnitOfWork unit = new UnitOfWork();
            
            List<Student> students = new List<Student>();
            foreach(Student s in unit.Students.GetAll())
            {
                
                if (s.course.ToLower().Equals(X.ToLower()))
                    students.Add(s);

            }
            return View(students);
        }
    }
}