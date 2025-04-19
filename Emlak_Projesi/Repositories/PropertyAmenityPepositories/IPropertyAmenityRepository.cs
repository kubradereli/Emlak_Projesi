using Emlak_Projesi.Dtos.PropertyAmenityDtos;

namespace Emlak_Projesi.Repositories.PropertyAmenityPepositories
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id);
    }
}
