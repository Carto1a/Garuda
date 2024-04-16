using System.Net.WebSockets;
using Domain.Dtos.Websockets;
using Domain.Entities.Payloads;
using Domain.Entities.Servers.Users.Informations;
using Server.Entities.Servers;
using Server.Handlers.Websockets.Receive.Interfaces;
using Server.Handlers.Websockets.Send.Interfaces;
using Server.Services.Interfaces;

namespace Server.Entities.Websocket.Connections;
public class WebsocketConnection
{
    private readonly IPayloadSendHandler _payloadSendHandler;
    private readonly IDispatchHandler _dispatchHandler;
    private readonly IAuthenticatorService _authenticator;
    private readonly ServerEntity _server;
    public WebSocket ws { get; set; }
    public Guid Id { get; set; }
    public UserSimpleInfo? User { get; set; }
    public bool IsIdentified { get; set; }
    private Timer heartbeatTimer { get; set; }
    private Timer? disconnectTimer { get; set; }
    private Timer? indentifyTimer { get; set; }
    private bool _destroyed = false;
    public bool Destroyed => _destroyed;
    public byte[] buffer { get; set; }
    public RoomEntity? AtualRoom { get; set; } = null;
    public bool Anonymous { get; set; } = false;

    // TODO: verificar se o estado do websocket
    public WebsocketConnection(
        IPayloadSendHandler payloadSendHandler,
        IDispatchHandler dispatchHandler,
        IAuthenticatorService authenticator,
        WebSocket ws)
    {
        _payloadSendHandler = payloadSendHandler;
        _dispatchHandler = dispatchHandler;
        _authenticator = authenticator;
        _server = ServerEntity.Instance;
        buffer = new byte[1024 * 4];
        IsIdentified = false;
        this.ws = ws;
        // TODO: olhar timer
        this.heartbeatTimer = new Timer(_ =>
        {
            Console.WriteLine("Heartbeat Timeout");
            _payloadSendHandler.Heartbeat(this);
        },
        null, 42000, 42000);
        this.indentifyTimer = new Timer(_ =>
        {
            var payload = InvalidSessionCodes.AuthenticationFailed;
            Console.WriteLine("Indentify Timeout");
            _payloadSendHandler.InvalidSession(payload, this)
                .ContinueWith(_ => Disconnect());
        }, null, 1500, Timeout.Infinite);
    }

    ~WebsocketConnection()
    {
        Console.WriteLine("WebsocketConnection Destructor");
    }

    public void RestartHeartbeat()
    {
        heartbeatTimer?.Change(Timeout.Infinite, Timeout.Infinite);
        heartbeatTimer?.Change(42000, 42000);
    }

    public void StartDisconnectTimer()
    {
        disconnectTimer = new Timer(_ =>
        {
            var payload = InvalidSessionCodes.SessionTimeout;
            Console.WriteLine("Disconnect Timeout");
            _payloadSendHandler.InvalidSession(payload, this)
                .ContinueWith(_ => Disconnect());
        }, null, 1000, Timeout.Infinite);
    }

    public void StopDisconnectTimer()
    {
        disconnectTimer?.Dispose();
        disconnectTimer = null;
    }

    private void StopIndentifyTimer()
    {
        indentifyTimer?.Dispose();
        indentifyTimer = null;
    }

    public void Indentify(
        UserSimpleAuthenticateDto? request, bool anonymous = false)
    {
        StopIndentifyTimer();

        if (anonymous)
        {
            var user = _server.Users[Guid.Empty];
            SetUser(user);
            return;
        }

        if (request != null && _authenticator.Authenticate(request))
        {
            var user = _server.Users?.FirstOrDefault(u =>
                u.Value.Username == request.Username).Value;
            // TODO: isso esta feio
            if (user == null)
            {
                var id = Guid.NewGuid();
                user = new UserSimpleInfo(id, request.Username);
                _server.AddUser(user);
            }
            else
            {
                user = new UserSimpleInfo(user.ServerUserId, user.Username);
            }
            SetUser(user);
            return;
        }

        var payload = InvalidSessionCodes.AuthenticationFailed;
        Console.WriteLine("Indentify Failed");
        _payloadSendHandler.InvalidSession(payload, this)
            .ContinueWith(_ => Disconnect());
    }

    public Task SetUser(UserSimpleInfo user)
    {
        User = user;
        IsIdentified = true;
        _dispatchHandler.ReadyMethod(string.Empty, this);
        return Task.CompletedTask;
    }

    public Task Disconnect()
    {
        Console.WriteLine("Disconnecting");
        // NOTE: Zombie connection, meeedo
        _destroyed = true;
        if (IsIdentified)
            _dispatchHandler.DisconnectedMethod(this);

        ws.Abort();
        return ws.CloseOutputAsync(
            WebSocketCloseStatus.NormalClosure,
            "Disconnect",
            CancellationToken.None).ContinueWith(_ =>
            {
                _server.Remove(this);
                heartbeatTimer?.Dispose();
                disconnectTimer?.Dispose();
                indentifyTimer?.Dispose();
                ws.Dispose();
                Console.WriteLine("Disconnected");
            });
    }
}
