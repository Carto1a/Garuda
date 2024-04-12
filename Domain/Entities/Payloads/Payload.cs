using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads;
public class Payload<T>
{
    public OpCodes op { get; set; }
    public T? d { get; set; }
    /* public int S { get; set; } */
    /* public string T { get; set; } */

    public Payload(
        OpCodes op, T d)
    {
        this.op = op;
        this.d = d;
    }
}
