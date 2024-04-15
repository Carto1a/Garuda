using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class Ready
{
    public Ready()
    {}

    public static Dispatch<Ready> Create()
    {
        return new Dispatch<Ready>(
            nameof(DispatchEvents.READY),
            new Ready());
    }
}
