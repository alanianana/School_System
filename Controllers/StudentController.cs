using ExamProject.Entities;
using ExamProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ExamProject.Entities;
using ExamProject.Interfaces;
using System;
using ExamProject;

namespace School_System.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentController : Controller
    {


        private readonly IUnitOfWork _uow;
        private readonly MainDBContext _context;
        public StudentController(IUnitOfWork uow,MainDBContext context)
        {
            _uow = uow;
            _context = context;
        }

        [HttpGet("GetAllStudents")]

        public async Task<IActionResult> GetAllStudents()
        {
            var data = await _uow.StudentRepository.GetAllAsync();
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented // Optional, to format the output
            };
            var result = JsonConvert.SerializeObject(data, settings);

            return Ok(result);

        }
        [HttpGet("GetStudentById")]

        public async Task<IActionResult> GetStudentById(int studentIdNUmber)
        {
            var data = await _uow.StudentRepository.GetByIdNumber(studentIdNUmber);
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented // Optional, to format the output
            };
            var result = JsonConvert.SerializeObject(data, settings);

            return Ok(result);

        }


        [HttpPost("AddStudent")]

        public async Task<IActionResult> AddStudent(int idNumber,string firstName, string lastName, string email, DateTime DOB )
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                var newStudent = new StudentEntity
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Email = email,
                                StudnetIdNumber = idNumber,
                                Age = DOB
                
                            };
                await _uow.StudentRepository.Add(newStudent);
                await _context.Database.CommitTransactionAsync();
                            return Ok(newStudent);
            }catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }
            

        }

        [HttpPut("UpdateStudentInfo")]
        public async Task<IActionResult> UpdateStudentInf(int idNumber, string firstName, string lastName, string email, DateTime dbo)
        {
            var student = await _uow.StudentRepository.GetByIdNumber(idNumber);

            if (student == null) throw new Exception("Student Does Not Exist!");
            try
            {
                await _context.Database.BeginTransactionAsync();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Email = email;
                student.Age = dbo;


                await _uow.StudentRepository.Update(student);
                await _context.Database.CommitTransactionAsync();
                return Ok();

            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }

            
        }
        [HttpDelete("Delete Student")]

        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {

                await _context.Database.BeginTransactionAsync();
                var student = await _uow.StudentRepository.GetById(id);
                await _uow.StudentRepository.Delete(student);
                await _context.Database.CommitTransactionAsync();
                return Ok();
            }catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }
            

        }

    }
}
