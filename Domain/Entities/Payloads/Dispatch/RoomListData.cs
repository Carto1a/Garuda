using Domain.Entities.Servers;
using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class RoomListData
{
    public IList<Room> rooms { get; set; }
    public int count => rooms.Count;

    public RoomListData(
        IList<Room> rooms)
    {
        this.rooms = rooms;
    }

    public static Dispatch<RoomListData> Create(
        IList<Room> rooms)
    {
        return new Dispatch<RoomListData>(
            nameof(DispatchEvents.ROOMS_LIST),
            new RoomListData(rooms)
        );
    }
}
