using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads.Invoke;
public class Invoke<Event>
: Payload<Event>
{
    public Invoke(string event_name, Event @event)
    : base(OpCodes.Dispatch, @event, event_name)
    {

    }
}
