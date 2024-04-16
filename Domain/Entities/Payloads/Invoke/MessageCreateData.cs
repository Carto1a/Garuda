using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class MessageCreateData
{
    public Guid? room_id { get; set; }
    public string? content { get; set; }

    public MessageCreateData(
        string content,
        Guid room_id)
    {
        this.content = content;
        this.room_id = room_id;
    }

    public static Invoke<MessageCreateData> Create(
        string content,
        Guid roomId)
    {
        return new Invoke<MessageCreateData>(
            nameof(InvokeEvents.MESSAGE_CREATE),
            new MessageCreateData(content, roomId));
    }
}
