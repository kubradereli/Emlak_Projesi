using Emlak_Projesi.Dtos.WhoWeAreDetailDtos;

namespace Emlak_Projesi.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();

        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);

        void DeleteWhoWeAreDetail(int id);

        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);

        Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id);
    }
}