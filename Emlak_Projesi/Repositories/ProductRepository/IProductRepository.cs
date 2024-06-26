using Emlak_Projesi.Dtos.ProductDtos;

namespace Emlak_Projesi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();

        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    }
}
