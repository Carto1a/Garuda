using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class Lefted
: Dispatch
{
    public Guid room_id { get; set; }
    public string username { get; set; }
    public DateTime left_at { get; set; }

    public Lefted(
        string username,
        Guid roomId,
        DateTime leftAt)
    : base(nameof(DispatchEvents.LEFTED))
    {
        this.username = username;
        this.left_at = leftAt;
        this.room_id = roomId;
    }
}
