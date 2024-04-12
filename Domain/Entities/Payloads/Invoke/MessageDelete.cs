using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class MessageDelete
: Invoke
{
    public Guid message_id { get; set; }

    public MessageDelete(
        Guid messageId)
    : base(nameof(InvokeEvents.MESSAGE_DELETE))
    {
        this.message_id = messageId;
    }
}
