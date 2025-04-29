using Dapper;
using Emlak_Projesi.Dtos.SubFeatureDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.SubFeatureRepositories
{
    public class SubFeaturesRepository : ISubFeaturesRepository
    {
        private readonly Context _context;

        public SubFeaturesRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync()
        {
            string query = "Select * From SubFeature";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSubFeatureDto>(query);
                return values.ToList();
            }
        }
    }
}
