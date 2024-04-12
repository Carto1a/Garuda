namespace Domain.Enums.Payloads;
public enum OpCodes
{
    Dispatch,     // receive
    Invoke,       // send
    Heartbeat,    // send, receive
    Identify,     // send
    Hello,        // receive
    HeartbeatAck, // receive
    Disconnect    // send
}
