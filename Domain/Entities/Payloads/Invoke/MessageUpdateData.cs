using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class MessageUpdateData
{
    public Guid message_id { get; set; }
    public string? content { get; set; }

    public MessageUpdateData(
        Guid messageId,
        string content)
    {
        this.message_id = messageId;
        this.content = content;
    }

    public static Invoke<MessageUpdateData> Create(
        Guid messageId,
        string content)
    {
        return new Invoke<MessageUpdateData>(
            nameof(InvokeEvents.MESSAGE_UPDATE),
            new MessageUpdateData(messageId, content));
    }
}
