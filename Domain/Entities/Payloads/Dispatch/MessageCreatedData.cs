using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class MessageCreatedData
{
    public Guid id { get; set; }
    public string username { get; set; }
    public string content { get; set; }
    public Guid room_id { get; set; }
    public DateTime created_at { get; set; }

    public MessageCreatedData(
        Guid id,
        string username,
        string content,
        Guid roomId)
    {
        this.id = id;
        this.username = username;
        this.content = content;
        this.room_id = roomId;
        this.created_at = DateTime.Now;
    }

    public static Dispatch<MessageCreatedData> Create(
        Guid id,
        string username,
        string content,
        Guid roomId,
        DateTime createdAt)
    {
        return new Dispatch<MessageCreatedData>(
            nameof(DispatchEvents.MESSAGE_CREATED),
            new MessageCreatedData(id, username, content, roomId));
    }
}
