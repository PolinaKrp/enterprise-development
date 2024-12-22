namespace HRDepartment.WebApplication.Api
{
    public interface IHRDepartmentApiWrapper
    {
        // Методы для работы с типами льгот
        Task CreateBenefitType(BenefitTypePostDto benefitTypeDto);
        Task<ICollection<BenefitTypeGetDto>> GetAllBenefitTypes();
        Task<BenefitTypeGetDto> GetBenefitTypeById(int id);
        Task UpdateBenefitType(int id, BenefitTypePostDto benefitTypeDto);
        Task DeleteBenefitType(int id);

        // Методы для работы с сотрудниками
        Task CreateEmployee(EmployeePostDto employeePostDto);
        Task<ICollection<EmployeeGetDto>> GetAllEmployees();
        Task<EmployeeGetDto> GetEmployeeById(int id);
        Task UpdateEmployee(int id, EmployeePostDto employeePostDto);
        Task DeleteEmployee(int id);

        // Методы для работы с отделами
        Task CreateDepartment(DepartmentPostDto departmentPostDto);
        Task<ICollection<DepartmentGetDto>> GetAllDepartments();
        Task<DepartmentGetDto> GetDepartmentById(int id);
        Task UpdateDepartment(int id, DepartmentPostDto departmentPostDto);
        Task DeleteDepartment(int id);

        // Методы для работы с позициями
        Task CreatePosition(PositionPostDto positionPostDto);
        Task<ICollection<PositionGetDto>> GetAllPositions();
        Task<PositionGetDto> GetPositionById(int id);
        Task UpdatePosition(int id, PositionPostDto positionPostDto);
        Task DeletePosition(int id);

        // Методы для работы с цехами
        Task CreateWorkshop(WorkshopPostDto workshopPostDto);
        Task<ICollection<WorkshopGetDto>> GetAllWorkshops();
        Task<WorkshopGetDto> GetWorkshopById(int id);
        Task UpdateWorkshop(int id, WorkshopPostDto workshopPostDto);
        Task DeleteWorkshop(int id);
    }
}