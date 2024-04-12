using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class Leave
: Invoke
{
    public Guid room_id { get; set; }

    public Leave(
        Guid roomId)
    : base(nameof(InvokeEvents.LEAVE))
    {
        this.room_id = roomId;
    }
}
