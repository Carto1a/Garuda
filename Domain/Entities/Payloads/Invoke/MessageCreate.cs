using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class MessageCreate
: Invoke
{
    public Guid? room_id { get; set; }
    public string? content { get; set; }

    public MessageCreate(
        string content,
        Guid room_id)
    : base(nameof(InvokeEvents.MESSAGE_CREATE))
    {
        this.content = content;
        this.room_id = room_id;
    }
}
