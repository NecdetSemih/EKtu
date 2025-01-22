using EKtu.Application.IRepository;
using EKtu.Application.IService;
using EKtu.Application.Service;
using EKtu.Persistence.Database;
using EKtu.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy.WithOrigins("https://localhost:7146")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<EKtu.Application.IRepository.IStudentService, StudentRepository>();
builder.Services.AddScoped<EKtu.Application.IService.IStudentService, StudentService>();
builder.Services.AddScoped<EKtu.Application.IService.IInstructorService, InstructorService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<EKtu.Application.IRepository.IInstructorService, InstructorRepository>();

builder.Services.AddDbContext<AppDbContext>(conf => conf.UseSqlServer("Server=DESKTOP-F9749JC\\SQLEXPRESS;Database=EKtu;Trusted_Connection=True; TrustServerCertificate=True;"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
