using System.Net.WebSockets;
using Domain.Dtos.Websockets;
using Server.Handlers.Websockets.Receive.Interfaces;
using Server.Handlers.Websockets.Send.Interfaces;
using Server.Services.Interfaces;

namespace Server.Entities.Websocket.Connections;
public class WebsocketConnection
{
    private readonly IPayloadSendHandler _payloadSendHandler;
    private readonly IDispatchHandler _dispatchHandler;
    private readonly IAuthenticatorService _authenticator;
    public WebSocket ws { get; set; }
    private Timer heartbeatTimer { get; set; }
    private Timer? disconnectTimer { get; set; }
    private Timer? indentifyTimer { get; set; }

    public WebsocketConnection(
        IPayloadSendHandler payloadSendHandler,
        IDispatchHandler dispatchHandler,
        IAuthenticatorService authenticator,
        WebSocket ws)
    {
        _payloadSendHandler = payloadSendHandler;
        _dispatchHandler = dispatchHandler;
        _authenticator = authenticator;
        this.ws = ws;
        this.heartbeatTimer = new Timer(_ =>
        {
            _payloadSendHandler.Heartbeat(this);
        },
        null, 0, 42000);
        this.indentifyTimer = new Timer(_ =>
        {
            _payloadSendHandler.Disconnect(this);
        }, null, 0, 1000);
    }

    public void RestartHeartbeat()
    {
        heartbeatTimer?.Change(Timeout.Infinite, Timeout.Infinite);
        heartbeatTimer?.Change(0, 42000);
    }

    public void StartDisconnectTimer()
    {
        disconnectTimer = new Timer(_ =>
        {
            _payloadSendHandler.Disconnect(this);
        }, null, 0, 500);
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

    public void Indentify(UserSimpleAuthenticateDto request)
    {
        if (_authenticator.Authenticate(request))
        {
            StopIndentifyTimer();
            _dispatchHandler.ReadyMethod(string.Empty, this);
            return;
        }

        // TODO: Invalid session
        _payloadSendHandler.Disconnect(this);
    }

    public async void Disconnect()
    {
        await _payloadSendHandler.Disconnect(this);
        await ws.CloseAsync(
            WebSocketCloseStatus.NormalClosure,
            "Disconnect",
            CancellationToken.None);
        heartbeatTimer.Dispose();
        disconnectTimer?.Dispose();
        ws.Dispose();
    }
}
