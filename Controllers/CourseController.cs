using ExamProject.Entities;
using ExamProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExamProject.Controllers
{
    [ApiController] 
    [Route("[Controller]")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly MainDBContext _context;
        public CourseController(IUnitOfWork uow, MainDBContext context)
        {
            _uow = uow;
            _context = context;
        }


        [HttpGet("GetAllCourse")]

        public async Task<IActionResult> GetAllCourses()
        {
            var data = _uow.CourseRepository.GetAll();
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented // Optional, to format the output
            };
            var result = JsonConvert.SerializeObject(data, settings);

            return Ok(result);
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse(string name, string description, int price, int quantity,int teacherIdNumber)
        {
            var teacher = _uow.TeacherRepository.GetTeacherByIdNUmber(teacherIdNumber);
            try
            {
                await _context.Database.BeginTransactionAsync();
                var newCourse = new CourseEntity
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    Quantity = quantity,
                    // TeacherId = teacher.Id 
                };
                await _uow.CourseRepository.Add(newCourse);
                await _context.Database.CommitTransactionAsync();
                return Ok(newCourse);
            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }

        }
        


        [HttpDelete("DeleteCourse")]

        public async Task<IActionResult> DeleteCourse(string name)
        {
            try
            {
                await _context.Database.BeginTransactionAsync();
                var course = await _uow.CourseRepository.GetCourseByName(name);
                await _uow.CourseRepository.Delete(course);
                return Ok();
            }catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                throw ex;
            }
            

        }

    }
}
