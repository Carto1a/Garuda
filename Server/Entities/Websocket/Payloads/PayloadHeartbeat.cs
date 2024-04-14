using System.Text.Json;
using Domain.Entities.Payloads;
using Domain.Enums.Payloads;

namespace Server.Entities.Websocket.Payloads;
public static class PayloadHeartbeat
{
    public static ArraySegment<byte> Payload {get; }  = new ArraySegment<byte>(
        JsonSerializer.SerializeToUtf8Bytes(
            new Payload<object>(
                OpCodes.Heartbeat,
                null,
                null)));
}
