using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class MessageUpdate
{
    public Guid message_id { get; set; }
    public string? content { get; set; }

    public MessageUpdate(
        Guid messageId,
        string content)
    {
        this.message_id = messageId;
        this.content = content;
    }

    public static Invoke<MessageUpdate> Create(
        Guid messageId,
        string content)
    {
        return new Invoke<MessageUpdate>(
            nameof(InvokeEvents.MESSAGE_UPDATE),
            new MessageUpdate(messageId, content));
    }
}
