using System.Net.WebSockets;
using Client.Handlers.Websockets.Send.Interfaces;
using Domain.Entities.Payloads;
using Domain.Entities.Servers.Users.Informations;
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
    public UserSimpleInfo? User { get; set; }
    public bool isIdentified { get; set; } = false;
    public bool Destroyed { get; set; } = false;
    public Timer? HeartbeatTimer { get; set; }

    public UserConnection(
        IPayloadSendHandler sendHandler,
        Guid userId,
        WebSocket webSocket,
        UserSimpleInfo? user)
    {
        User = user;
        _sendHandler = sendHandler;
        UserId = userId;
        ws = webSocket;
        Buffer = new byte[1024];
    }

    public Task Initialize(int heartbeatInterval)
    {
        var anonymous = User == null;
        return Task.WhenAll(
            Identify(User.Username, null, null, anonymous),
            Heartbeat(heartbeatInterval));
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
                    password,
                    anonymous),
                null
            ).Serialize());
        return _sendHandler.Identify(this);
    }

    public Task Heartbeat(int interval)
    {
        HeartbeatTimer = new Timer(_ =>
        {
            _sendHandler.Heartbeat(this);
        },
        null, 0, interval);
        return Task.CompletedTask;
    }

    public Task ResetHeartbeat()
    {
        HeartbeatTimer?.Change(0, 0);
        HeartbeatTimer?.Change(0, 41000);
        return Task.CompletedTask;
    }

    public Task Destroy()
    {
        if (Destroyed)
            return Task.CompletedTask;
        Destroyed = true;
        HeartbeatTimer?.Dispose();
        ws.Dispose();
        return Task.CompletedTask;
    }

    public Task Disconnect()
    {
        // NOTE: zombie connection
        if (Destroyed)
            return Task.CompletedTask;
        Destroyed = true;

        HeartbeatTimer?.Dispose();

        return ws.CloseAsync(
            WebSocketCloseStatus.NormalClosure,
            "Connection closed",
            CancellationToken.None).ContinueWith(_ =>
            {
                ws.Dispose();
            });
    }
}

