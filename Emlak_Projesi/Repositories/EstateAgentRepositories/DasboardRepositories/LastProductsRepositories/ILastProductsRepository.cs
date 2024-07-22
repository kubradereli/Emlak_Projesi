using Emlak_Projesi.Dtos.ProductDtos;

namespace Emlak_Projesi.Repositories.EstateAgentRepositories.DasboardRepositories.LastProductsRepositories
{
    public interface ILastProductsRepository
    {
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id);
    }
}
