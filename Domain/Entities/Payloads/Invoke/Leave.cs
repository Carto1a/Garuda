using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class Leave
{
    public Guid room_id { get; set; }

    public Leave(
        Guid roomId)
    {
        this.room_id = roomId;
    }

    public static Invoke<Leave> Create(
        Guid roomId)
    {
        return new Invoke<Leave>(
            nameof(InvokeEvents.LEAVE),
            new Leave(roomId));
    }
}
