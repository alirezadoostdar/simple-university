using SimpleUniversity.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using SimpleUniversity.Application.Classes;
using SimpleUniversity.Application.Contracts;
using SimpleUniversity.Application.Students.Contracts;
using SimpleUniversity.Persistence.EF.Students;
using SimpleUniversity.Application.Students;
using SimpleUniversity.Application.SelectedClasses.Contracts;
using SimpleUniversity.Application.SelectedClasses;
using SimpleUniversity.Persistence.EF.SelectedClasses;
using SimpleUniversity.Application.Classes.Contracts;
using SimpleUniversity.Persistence.EF.Classes;
using SimpleUniversity.Application.Teachers.Contracts;
using SimpleUniversity.Persistence.EF.Teachers;
using SimpleUniversity.Application.Teachers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<EFDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>()
    .AddScoped<IStudentRepository, EFStudentRepository>()
    .AddScoped<IStudentService, StudentService>()
    .AddScoped<ISelectedClassService, SelectedClassService>()
    .AddScoped<ISelectedClassRepository, EFSelectedClassRepository>()
    .AddScoped<IClassRepository, EFClassRepository>()
    .AddScoped<IClassService, ClassService>()
    .AddScoped<ITeacherRepository, TeacherRepository>()
    .AddScoped<ITeacherService, TeacherService>();
    

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
