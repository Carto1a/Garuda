using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class Disconnected
{
    public Guid server_id { get; set; }
    public DateTime disconnected_at { get; set; }

    public Disconnected(
        Guid serverId,
        DateTime disconnectedAt)
    {
        this.server_id = serverId;
        this.disconnected_at = disconnectedAt;
    }

    public static Dispatch<Disconnected> Create(
        Guid serverId,
        DateTime disconnectedAt)
    {
        return new Dispatch<Disconnected>(
            nameof(DispatchEvents.DISCONNECTED),
            new Disconnected(serverId, disconnectedAt));
    }
}
