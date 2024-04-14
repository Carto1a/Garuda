using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class MessageDelete
{
    public Guid message_id { get; set; }

    public MessageDelete(
        Guid messageId)
    {
        this.message_id = messageId;
    }

    public static Invoke<MessageDelete> Create(
        Guid messageId)
    {
        return new Invoke<MessageDelete>(
            nameof(InvokeEvents.MESSAGE_DELETE),
            new MessageDelete(messageId));
    }
}
