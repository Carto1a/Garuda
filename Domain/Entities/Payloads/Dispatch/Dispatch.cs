using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Dispatch;
public class Dispatch<Event>
: Payload<Event>
{
    public Dispatch(string event_name, Event @event)
    : base(OpCodes.Dispatch, @event, event_name)
    { }
}
