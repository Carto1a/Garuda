using Domain.Entities.Servers;
using Domain.Entities.Servers.Messages;

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

    public static MessageEntity Create(
        Guid roomId,
        Guid userId,
        string content)
    {
        return new MessageEntity(
            roomId,
            userId,
            Guid.NewGuid(),
            content
        );
    }

    public Task Reply(Reply reply)
    {
        reply.MessageId = Id;
        return Task.CompletedTask;
    }
}
