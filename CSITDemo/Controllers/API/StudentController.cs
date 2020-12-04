using CSITDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSITDemo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public List<StudentModel> Get()
        {
            return GetStudentsFromDb();
        }

        private List<StudentModel> GetStudentsFromDb()
        {
            List<StudentModel> students = new List<StudentModel>();
            students.Add(new StudentModel { Name = "student 1", Address = "maitidevi" });
            students.Add(new StudentModel { Name = "student 2", Address = "balaju" });
            students.Add(new StudentModel { Name = "student 3", Address = "biratnagar" });

            return students;
        }
    }
}
