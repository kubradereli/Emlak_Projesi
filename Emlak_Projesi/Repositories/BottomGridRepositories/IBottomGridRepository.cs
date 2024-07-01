using Emlak_Projesi.Dtos.BottomGridDtos;

namespace Emlak_Projesi.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();

        void CreateBottomGrid(CreateBottomGridDto createBottomGridDto);

        void DeleteBottomGrid(int id);

        void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);

        Task<GetBottomGridDto> GetBottomGrid(int id);
    }
}
