using System.Net.WebSockets;
using Client.Handlers.Websockets.Send.Interfaces;
using Domain.Entities.Payloads;
using Domain.Enums.Payloads;

namespace Client.Entities.Websockets;
public class UserConnection
{
    private readonly IPayloadSendHandler _sendHandler;
    public Guid UserId { get; set; }
    public Guid? UserServerId { get; set; }
    public WebSocket ws { get; set; }
    public byte[] Buffer { get; set; }
    public ArraySegment<byte>? IdentifyPayloadUser { get; set; }
    public bool isIdentified { get; set; } = false;
    public Timer? HeartbeatTimer { get; set; }

    public UserConnection(Guid userId, WebSocket webSocket)
    {
        UserId = userId;
        ws = webSocket;
        Buffer = new byte[1024];
    }

    private Task InitiateConnection()
    {
        return Task.CompletedTask;
    }

    public Task Identify(
        string? username,
        string? email,
        string? password,
        bool anonymous = false)
    {
        IdentifyPayloadUser = new ArraySegment<byte>(
            new Payload<IdentifyPayload>(
                OpCodes.Identify,
                new IdentifyPayload(
                    username,
                    email,
                    password
                    anonymous
                ),
                null
            ).Serialize());
        return Task.CompletedTask;
    }

    public Task Heartbeat(int interval)
    {
        HeartbeatTimer = new Timer(_ =>
        {
            if (ws.State == WebSocketState.Open)
            {
                
            }
        },
        null, 0, interval);
        return Task.CompletedTask;
    }

    public Task Disconnect()
    {
        return Task.CompletedTask;
    }
}

