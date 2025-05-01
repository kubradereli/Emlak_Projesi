using Emlak_Projesi.Dtos.WhoWeAreDetailDtos;

namespace Emlak_Projesi.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetail();

        Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);

        Task DeleteWhoWeAreDetail(int id);

        Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);

        Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id);
    }
}