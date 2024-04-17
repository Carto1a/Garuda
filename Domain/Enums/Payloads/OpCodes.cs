namespace Domain.Enums.Payloads;
public enum OpCodes
{
    Dispatch,       // send, receive
    Heartbeat,      // send, receive
    Identify,       // send
    Hello,          // receive
    HeartbeatAck,   // receive
    InvalidSession, // receive
}
