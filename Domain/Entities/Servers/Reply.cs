namespace Domain.Entities.Servers;
public class Reply
: Message
{
    public Guid MessageId { get; set; }

    public Reply(
        Guid roomId,
        Guid userId,
        Guid replyId,
        string content)
    : base(roomId, userId, replyId, content)
    {
        MessageId = Guid.Empty;
    }
}
