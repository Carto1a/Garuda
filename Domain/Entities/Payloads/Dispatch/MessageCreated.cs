using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class MessageCreated
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
    {
        this.id = id;
        this.username = username;
        this.content = content;
        this.room_id = roomId;
        this.created_at = createdAt;
    }

    public static Dispatch<MessageCreated> Create(
        Guid id,
        string username,
        string content,
        Guid roomId,
        DateTime createdAt)
    {
        return new Dispatch<MessageCreated>(
            nameof(DispatchEvents.MESSAGE_CREATED),
            new MessageCreated(id, username, content, roomId, createdAt));
    }
}
