using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class JoinData
{
    public Guid room_id { get; set; }

    public JoinData(
        Guid roomId)
    {
        this.room_id = roomId;
    }

    public static Invoke<JoinData> Create(
        Guid roomId)
    {
        return new Invoke<JoinData>(
            nameof(InvokeEvents.JOIN),
            new JoinData(roomId));
    }
}
