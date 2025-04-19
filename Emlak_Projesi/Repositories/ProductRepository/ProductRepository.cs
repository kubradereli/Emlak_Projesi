using Dapper;
using Emlak_Projesi.Dtos.ProductDetailDtos;
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

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (Title, Price, City, District, CoverImage, Address, Description, Type, DealOfTheDay, AdvertisementDate, ProductStatus, ProductCategory, EmployeeID) values (@Title, @Price, @City, @District, @CoverImage, @Address, @Description, @Type, @DealOfTheDay, @AdvertisementDate, @ProductStatus, @ProductCategory, @EmployeeID)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@Title", createProductDto.Title);
            paramaters.Add("@Price", createProductDto.Price);
            paramaters.Add("@City", createProductDto.City);
            paramaters.Add("@District", createProductDto.District);
            paramaters.Add("@CoverImage", createProductDto.CoverImage);
            paramaters.Add("@Address", createProductDto.Address);
            paramaters.Add("@Description", createProductDto.Description);
            paramaters.Add("@Type", createProductDto.Type);
            paramaters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            paramaters.Add("@AdvertisementDate", createProductDto.AdvertisementDate);
            paramaters.Add("@ProductStatus", createProductDto.ProductStatus);
            paramaters.Add("@ProductCategory", createProductDto.ProductCategory);
            paramaters.Add("@EmployeeID", createProductDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
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
            string query = "Select ProductID, Title, Price, City, District, CategoryName, CoverImage, Type, Address, DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID, Title, Price, City, District, ProductCategory, CategoryName, AdvertisementDate From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Where Type='Kiralık' Order By ProductID Desc";
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "Select ProductID, Title, Price, City, District, CategoryName, CoverImage, Type, Address, DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID And ProductStatus=0";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeeID", id);
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, paramaters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "Select ProductID, Title, Price, City, District, CategoryName, CoverImage, Type, Address, DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeeID=@employeeID And ProductStatus=1";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeeID", id);
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, paramaters);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIdDto> GetProductByProductId(int id)
        {
            string query = "Select ProductID, Title, Price, City, Description, District, CategoryName, CoverImage, Type, Address, DealOfTheDay, AdvertisementDate From Product inner join Category on Product.ProductCategory=Category.CategoryID Where ProductID=@productID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByProductIdDto>(query, paramaters);
                return values.FirstOrDefault();
            }
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id)
        {
            string query = "Select * From ProductDetails Where ProductID=@productID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, paramaters);
                return values.FirstOrDefault();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product set DealOfTheDay=0 Where ProductID=@productID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product set DealOfTheDay=1 Where ProductID=@productID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
