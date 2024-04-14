using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class Join
{
    public Guid room_id { get; set; }

    public Join(
        Guid roomId)
    {
        this.room_id = roomId;
    }

    public static Invoke<Join> Create(
        Guid roomId)
    {
        return new Invoke<Join>(
            nameof(InvokeEvents.JOIN),
            new Join(roomId));
    }
}
