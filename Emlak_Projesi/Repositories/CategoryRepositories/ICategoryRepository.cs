using Emlak_Projesi.Dtos.CategoryDtos;

namespace Emlak_Projesi.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();

        void CreateCategory(CreateCategoryDto categoryDto);

        void DeleteCategory(int id);

        void UpdateCategory(UpdateCategoryDto categoryDto);

        Task<GetBYIDCategoryDto> GetCategory(int id);
    }
}
