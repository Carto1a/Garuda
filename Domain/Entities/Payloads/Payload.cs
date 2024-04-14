using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads;
public class Payload<Type>
{
    public OpCodes op { get; set; }
    public Type? d { get; set; }
    public string? t { get; set; }
    public int? s { get; set; }

    public Payload(
        OpCodes op, Type? d, string? t)
    {
        this.op = op;
        this.d = d;
        this.t = t;
    }
}
