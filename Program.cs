using ExamProject.Interfaces;
using ExamProject.Repositories;
using Microsoft.EntityFrameworkCore;
using School_System.Repositories;

namespace ExamProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<ITeacherRepository, TeacherRepository >();
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();
            builder.Services.AddTransient<IStudentCourseRepository, StudentCourseRepository>();


            var conncectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<MainDBContext>(options => options.UseSqlServer(conncectionString), ServiceLifetime.Singleton);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}