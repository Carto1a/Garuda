using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class Disconnected
: Dispatch
{
    public string username { get; set; }
    public Guid server_id { get; set; }
    public DateTime disconnected_at { get; set; }

    public Disconnected(
        string username,
        Guid serverId,
        DateTime disconnectedAt)
    : base(nameof(DispatchEvents.DISCONNECTED))
    {
        this.username = username;
        this.server_id = serverId;
        this.disconnected_at = disconnectedAt;
    }
}
