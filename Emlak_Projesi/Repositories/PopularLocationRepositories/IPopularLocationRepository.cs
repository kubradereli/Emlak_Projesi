using Emlak_Projesi.Dtos.PopularLocationDtos;
using Emlak_Projesi.Dtos.PopularLocationDtos;

namespace Emlak_Projesi.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();

        void CreatePopularLocation(CreatePopularLocationDto popularLocationDto);

        void DeletePopularLocation(int id);

        void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto);

        Task<GetByIDPopularLocationDto> GetPopularLocation(int id);
    }
}
