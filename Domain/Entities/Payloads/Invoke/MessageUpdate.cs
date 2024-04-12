using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class MessageUpdate
: Invoke
{
    public Guid message_id { get; set; }
    public string? content { get; set; }

    public MessageUpdate(
        Guid messageId,
        string content)
    : base(nameof(InvokeEvents.MESSAGE_UPDATE))
    {
        this.message_id = messageId;
        this.content = content;
    }
}
