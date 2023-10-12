using ExamProject.Entities;
using ExamProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ExamProject.Entities;
using ExamProject.Interfaces;
using ExamProject;

namespace School_System.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly MainDBContext _context;

        public StudentCourseController(IUnitOfWork uow,MainDBContext context)
        {
            _uow = uow;
            _context = context;
        }

        [HttpGet("getAllStudentsWithCourses")]

        public async Task<IActionResult> GetAllStudentsWithCourses()
        {
            var data = _uow.StudentCourseRepository.GetAllAsync();
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented // Optional, to format the output
            };
            var result = JsonConvert.SerializeObject(data, settings);

            return Ok(result);
        }

        [HttpPost("AddStudentAndItsCourse")]
        public async Task<IActionResult> AddStudentAndItsCourse(int studentIdNumber, string courseName)
        {
            var student = await _uow.StudentRepository.GetByIdNumber(studentIdNumber);
            var course = await _uow.CourseRepository.GetCourseByName(courseName);

            var data = await _uow.StudentCourseRepository.GetByStudentIdAndCourseName(student.Id, course.Id);
            if (data == null) throw new Exception("You are already registered for this course");

            try
            {
                await _context.Database.BeginTransactionAsync();
                var studenAndItsCourse = new StudentCourseEntity
                {
                    StudentId = student.Id,
                    CourseId = course.Id

                };
                await _uow.StudentCourseRepository.Add(studenAndItsCourse);
                await _context.Database.CommitTransactionAsync();
                return Ok();
            }catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }

            


            
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                var data = await _uow.StudentCourseRepository.GetById(id);
                    await _uow.StudentCourseRepository.Delete(data);
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
