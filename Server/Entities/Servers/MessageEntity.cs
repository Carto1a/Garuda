using Domain.Entities.Servers;

namespace Server.Entities.Servers;
public class MessageEntity
: Message
{
    public MessageEntity(
        Guid roomId,
        Guid userId,
        Guid messageId,
        string content)
    : base(roomId, userId, messageId, content)
    {
    }

    public Task Reply(Reply reply)
    {
        reply.MessageId = Id;
        return Task.CompletedTask;
    }
}
