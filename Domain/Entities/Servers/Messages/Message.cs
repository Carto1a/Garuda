namespace Domain.Entities.Servers.Messages;
public class Message
{
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    // NOTE: Message Server have a Guid Empty
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsUpdated { get; set; }

    public Message(
        Guid messageId,
        Guid roomId,
        Guid userId,
        string content)
    {
        Id = messageId;
        RoomId = roomId;
        UserId = userId;
        Content = content;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
