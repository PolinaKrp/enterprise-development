using AutoMapper;
using HRDepartment.Api.Dto;
using HRDepartment.Api;
using HRDepartment.Api.Service;
using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;
using HRDepartment.Domain.UnitTest;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using HRDepartment.Domain;

var builder = WebApplication.CreateBuilder(args);

// Регистрация контекста базы данных
builder.Services.AddDbContext<HRDepartmentContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySQL"), new MySqlServerVersion(new Version(8, 0, 39))));

// Регистрация контроллеров
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Регистрация репозиториев
builder.Services.AddScoped<IRepository<BenefitType>, BenefitTypeRepository>();
builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();
builder.Services.AddScoped<IRepository<EmployeeBenefit>, EmployeeBenefitRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<EmployeePosition>, EmployeePositionRepository>();
builder.Services.AddScoped<IRepository<Position>, PositionRepository>();
builder.Services.AddScoped<IRepository<Workshop>, WorkshopRepository>();

// Регистрация сервисов с интерфейсами
builder.Services.AddScoped<IService<BenefitTypeGetDto, BenefitTypePostDto>, BenefitTypeService>();
builder.Services.AddScoped<IService<DepartmentGetDto, DepartmentPostDto>, DepartmentService>();
builder.Services.AddScoped<IService<EmployeeBenefitGetDto, EmployeeBenefitPostDto>, EmployeeBenefitService>();
builder.Services.AddScoped<IService<EmployeeGetDto, EmployeePostDto>, EmployeeService>();
builder.Services.AddScoped<IService<EmployeePositionGetDto, EmployeePositionPostDto>, EmployeePositionService>();
builder.Services.AddScoped<IService<PositionGetDto, PositionPostDto>, PositionService>();
builder.Services.AddScoped<IService<WorkshopGetDto, WorkshopPostDto>, WorkshopService>();

// Регистрация AutoMapper
builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();