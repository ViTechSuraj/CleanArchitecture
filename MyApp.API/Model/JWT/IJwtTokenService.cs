using MyApp.Core.Entities.EmployeeMasterEntites;

namespace MyApp.Api.Model.JWT
{
    public interface IJwtTokenService
    {
        string GenerateToken(Employee employee);
    }
}
