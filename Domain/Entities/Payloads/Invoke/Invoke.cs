namespace Domain.Entities.Payloads.Invoke;
public class Invoke
{
    public string? event_name { get; set; }

    public Invoke(string @event)
    {
        event_name = @event;
    }
}
