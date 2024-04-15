using Domain.Entities.Payloads;
using Domain.Enums.Payloads;

namespace Server.Entities.Websocket.Payloads;
public static class PayloadHello
{
    public static ArraySegment<byte> Payload = new ArraySegment<byte>(
        new Payload<object>(
            OpCodes.Hello,
            new
            {
                // TODO: lidar com o numero magico
                heartbeat_interval = 41250,
            },
            null).Serialize());
}
