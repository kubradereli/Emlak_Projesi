using Emlak_Projesi.Dtos.ServiceDtos;

namespace Emlak_Projesi.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllService();

        Task CreateService(CreateServiceDto serviceDto);

        Task DeleteService(int id);

        Task UpdateService(UpdateServiceDto serviceDto);

        Task<GetByIDServiceDto> GetService(int id);
    }
}
