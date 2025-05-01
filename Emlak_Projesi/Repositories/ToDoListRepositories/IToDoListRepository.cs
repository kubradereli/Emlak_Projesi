using Emlak_Projesi.Dtos.ToDoListDtos;

namespace Emlak_Projesi.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoList();

        Task CreateToDoList(CreateToDoListDto categoryDto);

        Task DeleteToDoList(int id);

        Task UpdateToDoList(UpdateToDoListDto categoryDto);

        Task<GetBYIDToDoListDto> GetToDoList(int id);
    }
}
