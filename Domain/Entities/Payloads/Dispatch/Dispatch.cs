namespace Domain.Entities.Payloads.Dispatch;
public class Dispatch
{
    public string? event_name { get; set; }

    public Dispatch(string @event)
    {
        event_name = @event;
    }
}
