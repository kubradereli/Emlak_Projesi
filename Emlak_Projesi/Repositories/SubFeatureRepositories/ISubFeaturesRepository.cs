using Emlak_Projesi.Dtos.SubFeatureDtos;

namespace Emlak_Projesi.Repositories.SubFeatureRepositories
{
    public interface ISubFeaturesRepository
    {
        Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync();
    }
}
