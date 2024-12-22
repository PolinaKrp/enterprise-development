using HRDepartment.WebApplication;
using HRDepartment.WebApplication.Api;

namespace BenefitTypeBooking.Client.API;

public class HRDepartmentApiWrapper(IConfiguration configuration)
{
    public readonly ServerApi client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task CreateBenefitType(BenefitTypePostDto BenefitTypePostDto) => await client.BenefitTypePOSTAsync(BenefitTypePostDto);

    public async Task<ICollection<BenefitTypeGetDto>> GetAllBenefitTypes() => await client.BenefitTypeAllAsync();

    public async Task<BenefitTypeGetDto> GetBenefitTypeById(int id) => await client.BenefitTypeGETAsync(id);

    public async Task UpdateBenefitType(int id, BenefitTypePostDto BenefitTypePostDto) => await client.BenefitTypePUTAsync(id, BenefitTypePostDto);

    public async Task DeleteBenefitType(int id) => await client.BenefitTypeDELETEAsync(id);

    public async Task CreateEmployee(EmployeePostDto EmployeePostDto) => await client.EmployeePOSTAsync(EmployeePostDto);

    public async Task<ICollection<EmployeeGetDto>> GetAllEmployees() => await client.EmployeeAllAsync();

    public async Task<EmployeeGetDto> GetEmployeeById(int id) => await client.EmployeeGETAsync(id);

    public async Task UpdateEmployee(int id, EmployeePostDto EmployeePostDto) => await client.EmployeePUTAsync(id, EmployeePostDto);

    public async Task DeleteEmployee(int id) => await client.EmployeeDELETEAsync(id);

    public async Task CreateDepartment(DepartmentPostDto DepartmentPostDto) => await client.DepartmentPOSTAsync(DepartmentPostDto);

    public async Task<ICollection<DepartmentGetDto>> GetAllDepartments() => await client.DepartmentAllAsync();

    public async Task<DepartmentGetDto> GetDepartmentById(int id) => await client.DepartmentGETAsync(id);

    public async Task UpdateDepartment(int id, DepartmentPostDto DepartmentPostDto) => await client.DepartmentPUTAsync(id, DepartmentPostDto);

    public async Task DeleteDepartment(int id) => await client.DepartmentDELETEAsync(id);

    public async Task CreateWorkshop(WorkshopPostDto WorkshopPostDto) => await client.WorkshopPOSTAsync(WorkshopPostDto);

    public async Task<ICollection<WorkshopGetDto>> GetAllWorkshops() => await client.WorkshopAllAsync();

    public async Task<WorkshopGetDto> GetWorkshopById(int id) => await client.WorkshopGETAsync(id);

    public async Task UpdateWorkshop(int id, WorkshopPostDto WorkshopPostDto) => await client.WorkshopPOSTAsync(WorkshopPostDto);

    public async Task DeleteWorkshop(int id) => await client.WorkshopDELETEAsync(id);
}
