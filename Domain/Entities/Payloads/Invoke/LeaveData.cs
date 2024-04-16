using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class LeaveData
{
    public Guid room_id { get; set; }

    public LeaveData(
        Guid roomId)
    {
        this.room_id = roomId;
    }

    public static Invoke<LeaveData> Create(
        Guid roomId)
    {
        return new Invoke<LeaveData>(
            nameof(InvokeEvents.LEAVE),
            new LeaveData(roomId));
    }
}
