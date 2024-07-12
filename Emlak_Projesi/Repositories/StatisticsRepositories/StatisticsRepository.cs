using Dapper;
using Emlak_Projesi.Dtos.EmployeeDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=1"; //Aktif kategori saysını verir
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) From Employee Where Status=1"; //Aktif personel saysını verir
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) From Product Where Title Like '%Daire%'"; //Ürünler içinde Daire kelimesi geçen ilan sayısını verir (toplam daire sayısı)
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent() //Ortalama kiralık fiyatı verir
        {
            string query = "Select Avg(Price) From Product Where Type='Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale() //Ortalama satılık fiyatı verir
        {
            string query = "Select Avg(Price) From Product Where Type='Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int AverageRoomCount()
        {
            string query = "Select Avg(RoomCount) From ProductDetails"; //Ortalama oda sayısını verir
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount() //Toplam kategori sayısını verir
        {
            string query = "Select Count(*) From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount() //En fazla ürünü olan kategorinin adını verir
        {
            string query = "Select Top(1) CategoryName,Count(*) From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Group By CategoryName Order By Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProductCount() //En fazla ürünü olan şehri verir
        {
            string query = "Select Top(1) City, Count(*) as [product_count] From Product Group By City Order By product_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int DifferentCityCount() //İlanların kaç farklı şehirde olduğu bilgisini verir
        {
            string query = "Select Count(Distinct(City)) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount() //En fazla ilanı olan personel saysını verir
        {
            string query = "Select Name, Count(*) as [product_count] From Product Inner Join Employee On Product.EmployeeID=Employee.EmployeeID Group By Name Order By product_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice() //Eklenen son ürünün fiyat bilgisini verir
        {
            string query = "Select Top(1) Price From Product Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string NewestBuildingYear() //En yeni bina yılını verir
        {
            string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string OldestBuildingYear() //En eski bina yılını verir
        {
            string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int PassiveCategoryCount() //Pasif kategori sayısını verir
        {
            string query = "Select Count(*) From Category Where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
