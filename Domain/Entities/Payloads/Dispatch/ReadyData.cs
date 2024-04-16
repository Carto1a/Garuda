using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class ReadyData
{
    public ReadyData()
    {}

    public static Dispatch<ReadyData> Create()
    {
        return new Dispatch<ReadyData>(
            nameof(DispatchEvents.READY),
            new ReadyData());
    }
}
