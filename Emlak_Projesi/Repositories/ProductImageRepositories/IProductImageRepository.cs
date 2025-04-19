using Emlak_Projesi.Dtos.ProductDetailDtos;
using Emlak_Projesi.Dtos.ProductImageDtos;

namespace Emlak_Projesi.Repositories.ProductImageRepositories
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int id);
    }
}
