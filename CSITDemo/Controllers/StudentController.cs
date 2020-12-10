using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSITDemo.Models;
using CSITDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace CSITDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;

        public StudentController(IStudentService service, IClassService classService)
        {
            _studentService = service;
            _classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = _studentService.GetAllStudents();
            var emailTask = _studentService.SendEmail(model);

            Console.WriteLine("Send email task started");
            Console.WriteLine("Sending...");

            var result = await emailTask;
            Console.WriteLine("Email sending task completed");

            return View(model);
        }

        //{baseURL}/Student/GetSingleStudent?id=1
        public IActionResult GetSingleStudent(int id)
        {
            var model = _studentService.GetStudentById(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new StudentModel();
            model.AvailableClasses = _classService.GetAllClasses()
                                     .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                                     .ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(StudentModel model)
        {
            _studentService.AddStudent(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _studentService.GetStudentById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentModel model)
        {

            _studentService.EditStudent(model);
            return RedirectToAction("Index");
        }
    }
}
