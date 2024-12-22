using HRDepartment.WebApplication;

namespace BenefitTypeBooking.Client.API;

public class HRDepartmentApiWrapper(IConfiguration configuration) 
{
    public readonly HRDepartmentApi client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task CreateBenefitType(BenefitTypePostDto BenefitTypePostDto) => await client.BenefitTypePOSTAsync(BenefitTypePostDto);

    public async Task<ICollection<BenefitTypeGetDto>> GetAllBenefitTypes() => await client.BenefitTypeAllAsync();

    public async Task<BenefitTypeGetDto> GetBenefitTypeById(int id) => await client.BenefitTypeGETAsync(id);

    public async Task UpdateBenefitType(int id, BenefitTypePostDto BenefitTypePostDto) => await client.BenefitTypePUTAsync(id, BenefitTypePostDto);

    public async Task DeleteBenefitType(int id) => await client.BenefitTypeDELETEAsync(id);
}
