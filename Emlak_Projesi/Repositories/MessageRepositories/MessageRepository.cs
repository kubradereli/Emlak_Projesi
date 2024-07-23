using Dapper;
using Emlak_Projesi.Dtos.MessageDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageLıstByReceiver(int id)
        {
            string query = "Select Top(3) MessageID, Name, Subject, Detail, SendDate, IsRead, UserImageUrl From Message Inner Join AppUser on Message.Sender=AppUser.UserID Where Receiver=@receiverID Order By MessageID Desc";
            var paramaters = new DynamicParameters();
            paramaters.Add("@receiverID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDto>(query, paramaters);
                return values.ToList();
            }
        }
    }
}
