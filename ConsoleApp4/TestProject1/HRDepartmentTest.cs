namespace HRDepartment.Tests;

using global::HRDepartment.Domain;
using System;
using Xunit;

/// <summary>
/// Unit ������������ � �������������� ������
/// </summary>
public class HRDepartmentTest : IClassFixture<HRDepartment>
{
    private readonly HRDepartment _fixture;

    /// <summary>
    /// �������������� ����� ��������� ������
    /// </summary>
    /// <param name="fixture">��������� ������ <see cref="HRDepartment"/>.</param>
    public HRDepartmentTest(HRDepartment fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// 1. ��������� ����� ���� ����������� ���������� ������
    /// </summary>
    [Fact]
    public void TestDisplayAllEmployees()
    {
        var employees = _fixture.HRData.Employees;

        Assert.Equal(5, employees.Count);
    }

    /// <summary>
    /// 2. ��������� ����� �����������, ���������� � ���������� �������, ������������� �� ���
    /// </summary>
    [Fact]
    public void TestEmployeesInMultipleDepartments()
    {
        var employeesInMultipleDepartments = _fixture.HRData.Employees
            .Where(e => _fixture.HRData.WorkHistories.Count(w => w.Employee.Id == e.Id) > 1)
            .OrderBy(e => e.Surname)
            .ThenBy(e => e.Name)
            .ThenBy(e => e.Patronymic);

        foreach (var employee in employeesInMultipleDepartments)
        {
            Console.WriteLine($"{employee.Surname} {employee.Name} {employee.Patronymic}");
        }
    }

    /// <summary>
    /// 3. ��������� ����� ������ �� �����������, ����������� ��������������� �����, ���, ���� ��������, �����, ���������� ���������
    /// </summary>
    [Fact]
    public void GetEmployeesWorkingInMultipleDepartments()
    {
        var hrDepartment = new HRDepartment();

        var employees = hrDepartment.HRData.Employees
            .Where(e => e.Departments.Count > 1)
            .OrderBy(e => e.Surname)
            .ThenBy(e => e.Name)
            .ThenBy(e => e.Patronymic)
            .ToList();

        Assert.NotEmpty(employees);
    }

    /// <summary>
    /// 4. ��������� ����� �������� �������� ����������� � ������ ������
    /// </summary>
    [Fact]
    public void GetAverageAgeOfEmployeesInEachDepartment()
    {
        var hrDepartment = new HRDepartment();

        var averageAges = hrDepartment.HRData.Departments
            .Select(d => new
            {
                DepartmentName = d.Name,
                AverageAge = d.Employees?.Average(e => (DateTime.Now.Year - e.BirthDate.Year)) ?? 0
            })
            .ToList();

        foreach (var averageAge in averageAges)
        {
            Console.WriteLine($"Department: {averageAge.DepartmentName}, Average Age: {averageAge.AverageAge}");
        }
    }

    /// <summary>
    /// 5. ��������� ����� �������� � �����������, ���������� � ������� ���� �������� ����������� ������� (� �������� ���� �������)
    /// </summary>
    [Fact]
    public void TestEmployeesWithUnionBenefits()
    {
        HRDepartment hrDepartment = new HRDepartment();

        var employeesWithUnionBenefits = hrDepartment.HRData.Benefits
            .Where(b => b.Type == " �������" && b.Date.Year == 2022)
            .Select(b => b.Employee)
            .Distinct()
            .ToList();

        Assert.NotEmpty(employeesWithUnionBenefits);

        // ��������� �����������
        Assert.Equal(1, employeesWithUnionBenefits.Count); 
        Assert.Equal(1, employeesWithUnionBenefits[0].Id);
    }

    /// <summary>
    /// 6. ��������� ����� ��� 5 �����������, ������� ���������� ���� ������ �� �����������
    /// </summary>
    [Fact]
    public void TestTop5EmployeesBySeniority()
    {
        HRDepartment hrDepartment = new HRDepartment();

        var top5Employees = hrDepartment.HRData.Employees
            .OrderByDescending(e => hrDepartment.HRData.WorkHistories
                .Where(w => w.Employee.Id == e.Id)
                .Select(w => (w.EndDate ?? DateTime.MaxValue) - w.StartDate)
                .DefaultIfEmpty(TimeSpan.Zero)
                .Sum(t => t.Days))
            .Take(5)
            .ToList();

        Assert.Equal(5, top5Employees.Count);

        Assert.Equal(2, top5Employees[0].Id); // ������ ���� ��������
        Assert.Equal(3, top5Employees[1].Id); // �������� ���� ���������
        Assert.Equal(1, top5Employees[2].Id); // ������ ���� ��������
        Assert.Equal(4, top5Employees[3].Id); // ������� ���� ����������
        Assert.Equal(5, top5Employees[4].Id); // ������ �������� ��������
    }
}