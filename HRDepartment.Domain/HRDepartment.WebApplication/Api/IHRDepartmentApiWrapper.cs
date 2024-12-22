namespace HRDepartment.WebApplication.Api
{
    public interface IHRDepartmentApiWrapper
    {
        Task CreateBenefitType(BenefitTypeGetDto BenefitTypeDto);
        Task<ICollection<BenefitTypeGetDto>> GetAllBenefitTypes();
        Task<BenefitTypeGetDto> GetBenefitTypeById(int id);
        Task UpdateBenefitType(int id, BenefitTypeGetDto BenefitTypeDto);
        Task DeleteBenefitType(int id);
    }
}
