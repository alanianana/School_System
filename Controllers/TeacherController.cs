using ExamProject.Entities;
using ExamProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ExamProject.Entities;
using ExamProject.Interfaces        ;
using ExamProject;

namespace School_System.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly MainDBContext _context;
        public TeacherController(IUnitOfWork uow,MainDBContext context)
        {
            _uow = uow;
            _context = context;
        }

        [HttpGet("GetAllTeachers")]

        public async Task<IActionResult> GetAllTeachers()
        {
            var data = _uow.TeacherRepository.GetAll();
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented // Optional, to format the output
            };
            var result = JsonConvert.SerializeObject(data, settings);


            return Ok(result);
        }
        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher(string firstName, string lastName, int idNumber, int experience)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                var newTeacher = new TeacherEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    TeacherIdNumber = idNumber,
                    Experience = experience

                };
                var settings = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented // Optional, to format the output
                };
                await _uow.TeacherRepository.Add(newTeacher);
                var result = JsonConvert.SerializeObject(newTeacher, settings);
                await _context.Database.CommitTransactionAsync();
                return Ok(result);
            }catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }

            

        }

        [HttpPut("UpdateTeacherInfo")]
        public async Task<IActionResult> UpdateTeacherInf(int idNumber, string firstName, string lastName, int experience)
        {
            var teacher = await _uow.TeacherRepository.GetTeacherByIdNUmber(idNumber);

            if (teacher == null) throw new Exception("Student Does Not Exist!");
            try
            {
                await _context.Database.BeginTransactionAsync();
                teacher.FirstName = firstName;
                teacher.LastName = lastName;
                teacher.Experience = experience;

                await _uow.TeacherRepository.Update(teacher);
                await _context.Database.CommitTransactionAsync();
                return Ok();
            }catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }

            
        }
        [HttpDelete("DeleteTeacher")]

        public async Task<IActionResult> Deleteteacher(int teacherID)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                var teacher = await _uow.TeacherRepository.GetTeacherByIdNUmber(teacherID);
                await _uow.TeacherRepository.Delete(teacher);
                await _context.Database.CommitTransactionAsync();
                return Ok();

            }catch(Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }
            

        }


    }
}
