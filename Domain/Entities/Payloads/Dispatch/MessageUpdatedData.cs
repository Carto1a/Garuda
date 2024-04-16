using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class MessageUpdatedData
{
    public Guid? message_id { get; set; }
    public string? content { get; set; }
    public DateTime updated_at { get; set; }

    public MessageUpdatedData(
        Guid messageId,
        string content,
        DateTime updatedAt)
    {
        this.message_id = messageId;
        this.content = content;
        this.updated_at = updatedAt;
    }

    public static Dispatch<MessageUpdatedData> Create(
        Guid messageId,
        string content,
        DateTime updatedAt)
    {
        return new Dispatch<MessageUpdatedData>(
            nameof(DispatchEvents.MESSAGE_UPDATED),
            new MessageUpdatedData(messageId, content, updatedAt));
    }
}
