using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSITDemo.Models;
using CSITDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CSITDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = _service.GetAllStudents();
            var emailTask = _service.SendEmail(model);

            Console.WriteLine("Send email task started");
            Console.WriteLine("Sending...");

            var result = await emailTask;
            Console.WriteLine("Email sending task completed");

            return View(model);
        }

        //{baseURL}/Student/GetSingleStudent?id=1
        public IActionResult GetSingleStudent(int id)
        {
            var model = _service.GetStudentById(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(StudentModel model)
        {
            _service.AddStudent(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _service.GetStudentById(id);
            return View(model);
        }
    }
}
