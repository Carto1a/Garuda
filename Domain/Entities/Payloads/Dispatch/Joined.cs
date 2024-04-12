using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class Joined
: Dispatch
{
    public Guid room_id { get; set; }
    public string username { get; set; }
    public DateTime joined_at { get; set; }

    public Joined(
        Guid roomId,
        string username,
        DateTime joinedAt)
    : base(nameof(DispatchEvents.JOINED))
    {
        this.room_id = roomId;
        this.username = username;
        this.joined_at = joinedAt;
    }
}
