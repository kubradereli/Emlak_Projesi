using Emlak_Projesi.Dtos.PopularLocationDtos;

namespace Emlak_Projesi.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocation();

        Task CreatePopularLocation(CreatePopularLocationDto popularLocationDto);

        Task DeletePopularLocation(int id);

        Task UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto);

        Task<GetByIDPopularLocationDto> GetPopularLocation(int id);
    }
}
