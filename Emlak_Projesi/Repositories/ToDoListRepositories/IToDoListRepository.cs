using Emlak_Projesi.Dtos.ToDoListDtos;

namespace Emlak_Projesi.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();

        void CreateToDoList(CreateToDoListDto categoryDto);

        void DeleteToDoList(int id);

        void UpdateToDoList(UpdateToDoListDto categoryDto);

        Task<GetBYIDToDoListDto> GetToDoList(int id);
    }
}
