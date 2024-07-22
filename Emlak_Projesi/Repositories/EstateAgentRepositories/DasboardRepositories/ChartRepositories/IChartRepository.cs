using Emlak_Projesi.Dtos.ChartDtos;

namespace Emlak_Projesi.Repositories.EstateAgentRepositories.DasboardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
        Task<List<ResultChartDto>> Get5CityForChart();
    }
}
