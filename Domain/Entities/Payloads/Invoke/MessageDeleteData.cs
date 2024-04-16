using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class MessageDeleteData
{
    public Guid message_id { get; set; }

    public MessageDeleteData(
        Guid messageId)
    {
        this.message_id = messageId;
    }

    public static Invoke<MessageDeleteData> Create(
        Guid messageId)
    {
        return new Invoke<MessageDeleteData>(
            nameof(InvokeEvents.MESSAGE_DELETE),
            new MessageDeleteData(messageId));
    }
}
