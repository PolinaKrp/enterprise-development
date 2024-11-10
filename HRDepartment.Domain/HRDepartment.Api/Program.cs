using AutoMapper;
using HRDepartment.Api;
using HRDepartment.Api.Service;
using HRDepartment.Domain.Model;
using HRDepartment.Domain.Repositories;
using HRDepartment.Domain.UnitTest;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Создаем экземпляр HRDepartmentData
var hrDepartmentData = new HRDepartmentData();

// Регистрация сервисов
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Регистрация репозиториев
builder.Services.AddSingleton<IRepository<BenefitType>>(new BenefitTypeRepository(hrDepartmentData.BenefitType));
builder.Services.AddSingleton<IRepository<Department>>(new DepartmentRepository(hrDepartmentData.Department));
builder.Services.AddSingleton<IRepository<EmployeeBenefit>>(new EmployeeBenefitRepository(hrDepartmentData.EmployeeBenefit));
builder.Services.AddSingleton<IRepository<Employee>>(new EmployeeRepository(hrDepartmentData.EmployeeOnlyWorkshopFilledFixture));
builder.Services.AddSingleton<IRepository<EmployeePosition>>(new EmployeePositionRepository(hrDepartmentData.EmployeePosition));
builder.Services.AddSingleton<IRepository<Position>>(new PositionRepository(hrDepartmentData.Position));
builder.Services.AddSingleton<IRepository<Workshop>>(new WorkshopRepository(hrDepartmentData.Workshop));

// Регистрация сервисов
builder.Services.AddScoped<BenefitTypeService>(); 
builder.Services.AddScoped<DepartmentService>(); 
builder.Services.AddScoped<EmployeeBenefitService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<EmployeePositionService>();
builder.Services.AddScoped<PositionService > ();
builder.Services.AddScoped<WorkshopService>();

// Регистрация AutoMapper
builder.Services.AddAutoMapper(typeof(Mapping)); // Убедитесь, что у вас есть класс Mapping для конфигурации AutoMapper

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