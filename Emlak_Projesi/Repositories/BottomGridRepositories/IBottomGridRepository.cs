using Emlak_Projesi.Dtos.BottomGridDtos;

namespace Emlak_Projesi.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGrid();

        Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto);

        Task DeleteBottomGrid(int id);

        Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);

        Task<GetBottomGridDto> GetBottomGrid(int id);
    }
}
