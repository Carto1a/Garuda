using Domain.Entities.Servers;
using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class RoomList
{
    public IList<Room> rooms { get; set; }
    public int count => rooms.Count;

    public RoomList(
        IList<Room> rooms)
    {
        this.rooms = rooms;
    }

    public static Dispatch<RoomList> Create(
        IList<Room> rooms)
    {
        return new Dispatch<RoomList>(
            nameof(DispatchEvents.ROOMS_LIST),
            new RoomList(rooms)
        );
    }
}
