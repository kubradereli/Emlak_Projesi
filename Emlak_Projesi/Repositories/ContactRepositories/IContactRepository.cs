using Emlak_Projesi.Dtos.ContactDtos;

namespace Emlak_Projesi.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();

        Task<List<Last4ContactResultDto>> GetLAst4Contact();

        void CreateContact(CreateContactDto createContactDto);

        void DeleteContact(int id);

        Task<GetByIDContactDto> GetContact(int id);
    }
}
