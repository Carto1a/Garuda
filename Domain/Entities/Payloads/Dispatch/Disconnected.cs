using Domain.Entities.Servers.Users.Informations;
using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class Disconnected
{
    public UserSimpleInfo user { get; set; }
    public DateTime disconnected_at { get; set; }

    public Disconnected(
        UserSimpleInfo user,
        DateTime disconnectedAt)
    {
        this.user = user;
        this.disconnected_at = disconnectedAt;
    }

    public static Dispatch<Disconnected> Create(
        UserSimpleInfo user,
        DateTime disconnectedAt)
    {
        return new Dispatch<Disconnected>(
            nameof(DispatchEvents.DISCONNECTED),
            new Disconnected(user, disconnectedAt));
    }
}
