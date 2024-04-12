using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class Join
: Invoke
{
    public Guid room_id { get; set; }

    public Join(
        Guid roomId)
    : base(nameof(InvokeEvents.JOIN))
    {
        this.room_id = roomId;
    }
}
