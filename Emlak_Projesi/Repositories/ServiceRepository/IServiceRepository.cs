using Emlak_Projesi.Dtos.ServiceDtos;

namespace Emlak_Projesi.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();

        void CreateService(CreateServiceDto serviceDto);

        void DeleteService(int id);

        void UpdateService(UpdateServiceDto serviceDto);

        Task<GetByIDServiceDto> GetService(int id);
    }
}
