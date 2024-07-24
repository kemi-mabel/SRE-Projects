using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{   
    // localhost:xxx/api/Students
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public StudentsController(ApplicationDBContext dbContext)
            {
                this.dbContext = dbContext;
            }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var allStudents = dbContext.StudentRegister.ToList();

            return Ok(allStudents);
        }

        [HttpGet("{id}")]
        
        public IActionResult GetStudentById(int id) 
        {
            var StudentId = dbContext.StudentRegister.Find(id);
               
            if (StudentId == null)
            {
                return NotFound();
            }
            
            return Ok(StudentId);
        }

        [HttpPost]

        public IActionResult AddStudent(AddStudentDto addStudentDto)
        {
            var studentEntity = new Student()
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                EmailAddress = addStudentDto.EmailAddress,
                Programme = addStudentDto.Programme,
                Level = addStudentDto.Level,
            };
            dbContext.StudentRegister.Add(studentEntity);
            dbContext.SaveChanges();
            return Ok(studentEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, EditStudentDto EditStudentDto)

        {
            var student = dbContext.StudentRegister.Find(id);

            if (student == null)
            {
                return NotFound();
            }
            
                student.FirstName = EditStudentDto.FirstName;
                student.LastName = EditStudentDto.LastName;
                student.EmailAddress = EditStudentDto.EmailAddress;
                student.Programme = EditStudentDto.Programme;
                student.Level = EditStudentDto.Level;

                dbContext.SaveChanges();
                return Ok(student);
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var student = dbContext.StudentRegister.Find(id);
        
        if (student == null)
            {
                return NotFound();
            }
            dbContext.StudentRegister.Remove(student);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}