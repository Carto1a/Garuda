using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads;
public class InvalidSessionPayload
{
    public string? reason { get; set; }
    public bool resumable { get; set; }
    public int? code { get; set; }

    public InvalidSessionPayload(
        string? reason,
        bool resumable,
        int? code)
    {
        this.reason = reason;
        this.resumable = resumable;
        this.code = code;
    }

    public static Payload<InvalidSessionPayload> Create(
        string? reason,
        bool resumable,
        int? code)
    {
        return new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(reason, resumable, code),
            null);
    }
}
