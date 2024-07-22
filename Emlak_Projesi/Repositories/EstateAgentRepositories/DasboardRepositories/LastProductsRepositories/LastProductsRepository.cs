using Dapper;
using Emlak_Projesi.Dtos.ProductDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.EstateAgentRepositories.DasboardRepositories.LastProductsRepositories
{
    public class LastProductsRepository : ILastProductsRepository
    {
        private readonly Context _context;

        public LastProductsRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            string query = "Select Top(5) ProductID, Title, Price, City, District, ProductCategory, CategoryName, AdvertisementDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID Order By ProductID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("employeeID", id);
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryAsync<ResultLast5ProductWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
