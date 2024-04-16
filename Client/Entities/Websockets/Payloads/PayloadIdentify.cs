using Domain.Entities.Payloads;
using Domain.Entities.Payloads.Invoke;
using Domain.Enums.Payloads;

namespace Client.Entities.Websockets.Payloads;
public class PayloadIdentify
{
    public static ArraySegment<byte> Payload = new ArraySegment<byte>(
        new Payload<IdentifyPayload>(
            OpCodes.Identify,
            new IdentifyPayload(
                null,
                null,
                null,
            ),
            null
            ).Serialize());

    public 
}
