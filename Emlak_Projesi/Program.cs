using Emlak_Projesi.Hubs;
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
using Emlak_Projesi.Repositories.TestimonialRepositories;
using Emlak_Projesi.Repositories.ToDoListRepositories;
using Emlak_Projesi.Repositories.WhoWeAreRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddTransient<IStatisticRepository, StatisticRepository>();
builder.Services.AddTransient<IChartRepository, ChartRepository>();
builder.Services.AddTransient<ILastProductsRepository, LastProductsRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IProductImageRepository, ProductImageRepository>();
builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();
builder.Services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();
    });
});
builder.Services.AddHttpClient();
builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
