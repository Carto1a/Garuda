using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class MessageUpdated
{
    public Guid? message_id { get; set; }
    public string? content { get; set; }
    public DateTime updated_at { get; set; }

    public MessageUpdated(
        Guid messageId,
        string content,
        DateTime updatedAt)
    {
        this.message_id = messageId;
        this.content = content;
        this.updated_at = updatedAt;
    }

    public static Dispatch<MessageUpdated> Create(
        Guid messageId,
        string content,
        DateTime updatedAt)
    {
        return new Dispatch<MessageUpdated>(
            nameof(DispatchEvents.MESSAGE_UPDATED),
            new MessageUpdated(messageId, content, updatedAt));
    }
}
