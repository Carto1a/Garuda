using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class MessageDeleted
: Dispatch
{
    public Guid message_id { get; set; }
    public Guid room_id { get; set; }
    public Guid deleted_by { get; set; }
    public DateTime deleted_at { get; set; }

    public MessageDeleted(
        Guid messageId,
        Guid roomId,
        Guid deletedBy,
        DateTime deletedAt)
    : base(nameof(DispatchEvents.MESSAGE_DELETED))
    {
        this.message_id = messageId;
        this.room_id = roomId;
        this.deleted_by = deletedBy;
        this.deleted_at = deletedAt;
    }
}
