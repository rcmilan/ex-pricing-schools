using app.DTOs;

namespace app.ServiceInterfaces
{
    public interface ISchoolService
    {
        Task<SchoolDto> GetDto(int id);
    }
}