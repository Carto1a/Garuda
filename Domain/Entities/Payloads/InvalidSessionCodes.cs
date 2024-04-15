using Domain.Enums.Payloads;

namespace Domain.Entities.Payloads;
public class InvalidSessionCodes
{
    private static InvalidSessionCodes _instance =
        new InvalidSessionCodes();

    public static InvalidSessionCodes Instance => _instance;

    private static IDictionary<int, string> _codes = new Dictionary<int, string>
    {
        { 4000, "Unknown error" },
        { 4001, "Unknown opcode" },
        { 4002, "Decode error" },
        { 4003, "Not authenticated" },
        { 4004, "Authentication failed" },
        { 4005, "Already authenticated" },
        { 4006, "Session no longer valid" },
        { 4007, "Session timeout" },
        { 4008, "Invalid Payload"}
    };

    public IDictionary<int, string> Codes => _codes;

    public static Payload<InvalidSessionPayload> UnknownError =>
        new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(
                _codes[4000],
                false,
                4000),
            null);

    public static Payload<InvalidSessionPayload> UnknownOpcode =>
        new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(
                _codes[4001],
                false,
                4001),
            null);

    public static Payload<InvalidSessionPayload> DecodeError =>
        new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(
                _codes[4002],
                false,
                4002),
            null);

    public static Payload<InvalidSessionPayload> NotAuthenticated =>
        new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(
                _codes[4003],
                false,
                4003),
            null);

    public static Payload<InvalidSessionPayload> AuthenticationFailed =>
        new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(
                _codes[4004],
                false,
                4004),
            null);

    public static Payload<InvalidSessionPayload> AlreadyAuthenticated =>
        new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(
                _codes[4005],
                false,
                4005),
            null);

    public static Payload<InvalidSessionPayload> SessionNoLongerValid =>
        new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(
                _codes[4006],
                false,
                4006),
            null);

    public static Payload<InvalidSessionPayload> SessionTimeout =>
        new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(
                _codes[4007],
                false,
                4007),
            null);

    public static Payload<InvalidSessionPayload> InvalidPayload =>
        new Payload<InvalidSessionPayload>(
            OpCodes.InvalidSession,
            new InvalidSessionPayload(
                _codes[4008],
                false,
                4008),
            null);
}
