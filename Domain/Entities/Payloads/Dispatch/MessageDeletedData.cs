using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class MessageDeletedData
{
    public Guid message_id { get; set; }
    public Guid room_id { get; set; }
    public Guid deleted_by { get; set; }
    public DateTime deleted_at { get; set; }

    public MessageDeletedData(
        Guid messageId,
        Guid roomId,
        Guid deletedBy,
        DateTime deletedAt)
    {
        this.message_id = messageId;
        this.room_id = roomId;
        this.deleted_by = deletedBy;
        this.deleted_at = deletedAt;
    }

    public static Dispatch<MessageDeletedData> Create(
        Guid messageId,
        Guid roomId,
        Guid deletedBy,
        DateTime deletedAt)
    {
        return new Dispatch<MessageDeletedData>(
            nameof(DispatchEvents.MESSAGE_DELETED),
            new MessageDeletedData(messageId, roomId, deletedBy, deletedAt));
    }
}
