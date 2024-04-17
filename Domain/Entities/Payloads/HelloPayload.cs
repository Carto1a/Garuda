using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads;
public class HelloPayload
{
    public int heartbeat_interval { get; set; }

    public HelloPayload(
        int heartbeat_interval)
    {
        this.heartbeat_interval = heartbeat_interval;
    }

    public static Payload<HelloPayload> Create(
        int heartbeat_interval)
    {
        return new Payload<HelloPayload>(
            OpCodes.Hello,
            new HelloPayload(heartbeat_interval),
            null);
    }
}
