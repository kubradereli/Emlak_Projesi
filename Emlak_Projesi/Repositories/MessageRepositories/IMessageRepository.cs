using Emlak_Projesi.Dtos.MessageDtos;

namespace Emlak_Projesi.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageLıstByReceiver(int id);
    }
}
