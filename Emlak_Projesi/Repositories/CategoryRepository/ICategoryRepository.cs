using Emlak_Projesi.Dtos.CategoryDtos;

namespace Emlak_Projesi.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategory();

        Task CreateCategory(CreateCategoryDto categoryDto);

        Task DeleteCategory(int id);

        Task UpdateCategory(UpdateCategoryDto categoryDto);

        Task<GetBYIDCategoryDto> GetCategory(int id);
    }
}
