using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HRDepartment.WebApplication;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(sp => new HRDepartmentApi(builder.Configuration["OpenApi:ServerUrl"], new HttpClient()));
builder.Services.AddBlazorise(options => { options.Immediate = true; })
               .AddBootstrap5Providers()
               .AddFontAwesomeIcons();

await builder.Build().RunAsync();

/*public class ServerApi
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ServerApi(string baseUrl, HttpClient httpClient)
    {
        _baseUrl = baseUrl;
        _httpClient = httpClient;
    }

    public async Task<List<BenefitTypeGetDto>> BenefitTypeAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<BenefitTypeGetDto>>($"{_baseUrl}/BenefitTypes");
    }

    public async Task<BenefitTypeGetDto> BenefitTypeGETAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<BenefitTypeGetDto>($"{_baseUrl}/BenefitTypes/{id}");
    }

    public async Task<BenefitTypeGetDto> BenefitTypePOSTAsync(BenefitTypePostDto benefitType)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/BenefitTypes", benefitType);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BenefitTypeGetDto>();
    }

    public async Task BenefitTypePUTAsync(int id, BenefitTypePostDto benefitType)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/BenefitTypes/{id}", benefitType);
        response.EnsureSuccessStatusCode();
    }

    public async Task BenefitTypeDELETEAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/BenefitTypes/{id}");
        response.EnsureSuccessStatusCode();
    }
}*/

//using Blazorise;
//using Blazorise.Bootstrap5;
//using Blazorise.Icons.FontAwesome;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using HRDepartment.WebApplication;



//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddSingleton(sp => new ServerApi(builder.Configuration["OpenApi:ServerUrl"], new HttpClient()));

//builder.Services.AddBlazorise(options => { options.Immediate = true; }).AddBootstrap5Providers().AddFontAwesomeIcons();

//await builder.Build().RunAsync();
