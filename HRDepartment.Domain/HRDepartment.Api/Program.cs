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

// Создаем экземпляр HRDepartmentData
var hrDepartmentData = new HRDepartmentData();

// Регистрация контроллеров
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<HRDepartmentContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySQL"), new MySqlServerVersion(new Version(8, 0, 39))));

// Регистрация репозиториев
builder.Services.AddSingleton<IRepository<BenefitType>>(new BenefitTypeRepository(hrDepartmentData.BenefitType));
builder.Services.AddSingleton<IRepository<Department>>(new DepartmentRepository(hrDepartmentData.Department));
builder.Services.AddSingleton<IRepository<EmployeeBenefit>>(new EmployeeBenefitRepository(hrDepartmentData.EmployeeBenefit));
builder.Services.AddSingleton<IRepository<Employee>>(new EmployeeRepository(hrDepartmentData.EmployeeOnlyWorkshopFilledFixture));
builder.Services.AddSingleton<IRepository<EmployeePosition>>(new EmployeePositionRepository(hrDepartmentData.EmployeePosition));
builder.Services.AddSingleton<IRepository<Position>>(new PositionRepository(hrDepartmentData.Position));
builder.Services.AddSingleton<IRepository<Workshop>>(new WorkshopRepository(hrDepartmentData.Workshop));

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