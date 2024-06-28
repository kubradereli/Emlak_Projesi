using Dapper;
using Emlak_Projesi.Dtos.ProductDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID, Title, Price, City, District, CategoryName, CoverImage, Type, Address From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
