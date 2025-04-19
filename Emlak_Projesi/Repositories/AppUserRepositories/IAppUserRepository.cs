using Emlak_Projesi.Dtos.AppUserDtos;

namespace Emlak_Projesi.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductDto> GetAppUserByProductId(int id);
    }
}
