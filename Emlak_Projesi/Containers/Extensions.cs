using Emlak_Projesi.Models.DapperContext;
using Emlak_Projesi.Repositories.AppUserRepositories;
using Emlak_Projesi.Repositories.BottomGridRepositories;
using Emlak_Projesi.Repositories.BottomGridRepository;
using Emlak_Projesi.Repositories.CategoryRepositories;
using Emlak_Projesi.Repositories.ContactRepositories;
using Emlak_Projesi.Repositories.EmployeeRepositories;
using Emlak_Projesi.Repositories.EstateAgentRepositories.DasboardRepositories.ChartRepositories;
using Emlak_Projesi.Repositories.EstateAgentRepositories.DasboardRepositories.LastProductsRepositories;
using Emlak_Projesi.Repositories.EstateAgentRepositories.DasboardRepositories.StatisticRepositories;
using Emlak_Projesi.Repositories.MessageRepositories;
using Emlak_Projesi.Repositories.PopularLocationRepositories;
using Emlak_Projesi.Repositories.ProductImageRepositories;
using Emlak_Projesi.Repositories.ProductRepository;
using Emlak_Projesi.Repositories.PropertyAmenityPepositories;
using Emlak_Projesi.Repositories.ServiceRepository;
using Emlak_Projesi.Repositories.StatisticsRepositories;
using Emlak_Projesi.Repositories.SubFeatureRepositories;
using Emlak_Projesi.Repositories.TestimonialRepositories;
using Emlak_Projesi.Repositories.ToDoListRepositories;
using Emlak_Projesi.Repositories.WhoWeAreRepository;

namespace Emlak_Projesi.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddTransient<Context>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IChartRepository, ChartRepository>();
            services.AddTransient<ILastProductsRepository, LastProductsRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
            services.AddTransient<ISubFeaturesRepository, SubFeaturesRepository>();
        }
    }
}
