using Emlak_Projesi.Dtos.TestimonialDtos;

namespace Emlak_Projesi.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    }
}
