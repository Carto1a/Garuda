using Domain.Entities.Servers.Users.Informations;
using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class DisconnectedData
{
    public UserSimpleInfo user { get; set; }
    public DateTime disconnected_at { get; set; }

    public DisconnectedData(
        UserSimpleInfo user,
        DateTime disconnectedAt)
    {
        this.user = user;
        this.disconnected_at = disconnectedAt;
    }

    public static Dispatch<DisconnectedData> Create(
        UserSimpleInfo user,
        DateTime disconnectedAt)
    {
        return new Dispatch<DisconnectedData>(
            nameof(DispatchEvents.DISCONNECTED),
            new DisconnectedData(user, disconnectedAt));
    }
}
