using System.Text.Json;
using Domain.Entities.Payloads;
using Domain.Enums.Payloads;

namespace Server.Entities.Websocket.Payloads;
public static class PayloadHeartbeatAck
{
    public static ArraySegment<byte> Payload = new ArraySegment<byte>(
        new Payload<object>(
            OpCodes.HeartbeatAck,
            null,
            null).Serialize());
}
