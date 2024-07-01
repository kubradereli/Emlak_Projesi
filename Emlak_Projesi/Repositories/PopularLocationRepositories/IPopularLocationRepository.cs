using Emlak_Projesi.Dtos.PopularLocationDtos;

namespace Emlak_Projesi.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
    }
}
