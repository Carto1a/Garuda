using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class MessageCreated
: Dispatch
{
    public Guid id { get; set; }
    public string username { get; set; }
    public string content { get; set; }
    public Guid room_id { get; set; }
    public DateTime created_at { get; set; }

    public MessageCreated(
        Guid id,
        string username,
        string content,
        Guid roomId,
        DateTime createdAt)
    : base(nameof(DispatchEvents.MESSAGE_CREATED))
    {
        this.id = id;
        this.username = username;
        this.content = content;
        this.room_id = roomId;
        this.created_at = createdAt;
    }
}
