using CSITDemo.DbModels;
using CSITDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

namespace CSITDemo.Services
{
    public class StudentOracleService : IStudentService
    {
        private readonly OrchidDbContext _dbContext;
        public StudentOracleService(OrchidDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StudentModel> GetAllStudents()
        {
            //List<Student> students = _dbContext.Students.ToList();
            //List<StudentModel> returnData = new List<StudentModel>();
            //foreach (var s in students)
            //{
            //    var st = new StudentModel
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        Address = s.Address,
            //        Email = s.Email
            //    };
            //    returnData.Add(st);
            //}
            //return returnData;

            return _dbContext.Students.Select(x => new StudentModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Email = x.Email
            }).ToList();
        }

        public StudentModel GetStudentById(int id)
        {
            var student = GetAllStudents().FirstOrDefault(x => x.Id == id);
            return student;
        }

        public async Task<int> SendEmail(List<StudentModel> model)
        {
            await Task.Delay(5000);
            foreach(var std in model)
            {
                Console.WriteLine($"Email sent to {std.Name}");
            }
            return 1;
        }

        public void AddStudent(StudentModel student)
        {
            var dbStudent = new Student
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                Email = student.Email
            };

            _dbContext.Students.Add(dbStudent);
            _dbContext.SaveChanges();
        }

        public void EditStudent(StudentModel student)
        {
            var dbStudent = _dbContext.Students.FirstOrDefault(x=>x.Id == student.Id);
            if (dbStudent != null)
            {
                dbStudent.Name = student.Name;
                dbStudent.Address = student.Address;
                dbStudent.Email = student.Email;
                _dbContext.Students.Update(dbStudent);
                _dbContext.SaveChanges();
            }
        }
    }
}
