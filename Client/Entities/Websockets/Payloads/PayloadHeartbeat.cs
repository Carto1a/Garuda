using Domain.Entities.Payloads;
using Domain.Enums.Payloads;

namespace Client.Entities.Websockets.Payloads;
public static class PayloadHeartbeat
{
    public static ArraySegment<byte> Payload = new ArraySegment<byte>(
        new Payload<object>(
            OpCodes.Heartbeat,
            null,
            null).Serialize());
}
