using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class MessageCreate
{
    public Guid? room_id { get; set; }
    public string? content { get; set; }

    public MessageCreate(
        string content,
        Guid room_id)
    {
        this.content = content;
        this.room_id = room_id;
    }

    public static Invoke<MessageCreate> Create(
        string content,
        Guid roomId)
    {
        return new Invoke<MessageCreate>(
            nameof(InvokeEvents.MESSAGE_CREATE),
            new MessageCreate(content, roomId));
    }
}
