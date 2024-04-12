using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class MessageUpdated
: Dispatch
{
    public Guid? message_id { get; set; }
    public string? content { get; set; }
    public DateTime updated_at { get; set; }

    public MessageUpdated(
        Guid messageId,
        string content,
        DateTime updatedAt)
    : base(nameof(DispatchEvents.MESSAGE_UPDATED))
    {
        this.message_id = messageId;
        this.content = content;
        this.updated_at = updatedAt;
    }
}
