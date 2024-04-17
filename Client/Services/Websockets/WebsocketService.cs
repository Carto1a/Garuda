using System.Net.WebSockets;
using Client.Entities.Websockets;
using Client.Handlers.Websockets.Receive.Interfaces;
using Client.Handlers.Websockets.Send.Interfaces;
using Client.Services.Intefaces;
using Domain.Entities.Servers.Users.Informations;

namespace Client.Services;
public class WebsocketService
: IWebsocketService
{
    private readonly IDictionary<WebSocketState, Func<UserConnection, WebSocketReceiveResult?, Task>> _handlers;
    private readonly IPayloadSendHandler _payloadSendHandler;
    private readonly IPayloadReceiveHandler _payloadReceiveHandler;
    public WebsocketService(
        IPayloadSendHandler payloadSendHandler,
        IPayloadReceiveHandler payloadReceiveHandler)
    {
        _payloadSendHandler = payloadSendHandler;
        _payloadReceiveHandler = payloadReceiveHandler;
        _handlers = new Dictionary<WebSocketState, Func<UserConnection, WebSocketReceiveResult?, Task>>
        {
            { WebSocketState.Open, HandleOpen },
            { WebSocketState.CloseReceived, HandleCloseReceived },
            { WebSocketState.CloseSent, HandleCloseSent },
            { WebSocketState.Closed, HandleClosed },
            { WebSocketState.Aborted, HandleAborted }
        };
    }

    public Task Handle(UserSimpleInfo? user)
    {
        using var ws = new ClientWebSocket();
        ws.ConnectAsync(
            new Uri("ws://localhost:5281/ws"), CancellationToken.None).Wait();

        var userConnection = new UserConnection(
            _payloadSendHandler, Guid.NewGuid(), ws, user);

        while (ws.State == WebSocketState.Open)
        {
            WebSocketReceiveResult? payload = GetPayload(ws, userConnection.Buffer)?.Result;
            if (payload == null)
            {
                Console.WriteLine("Payload is null");
                continue;
            }

            var handler = _handlers[ws.State];
            if (handler == null)
            {
                Console.WriteLine("Handler is null");
                continue;
            }
            handler(userConnection, payload);
        }

        var handlerState = _handlers[ws.State];
        if (handlerState == null)
        {
            Console.WriteLine("HandlerState is null");
            return Task.CompletedTask;
        }
        return handlerState(userConnection, null);
    }

    private Task HandleOpen(
        UserConnection user, WebSocketReceiveResult? payload)
    {
        Console.WriteLine("WebsocketService.HandleOpen");
        return _payloadReceiveHandler.Handle(user.Buffer, user, payload);
    }

    private Task HandleCloseReceived(
        UserConnection user, WebSocketReceiveResult? payload)
    {
        Console.WriteLine("WebsocketService.HandleCloseReceived");
        return user.Destroy();
    }

    private Task HandleCloseSent(
        UserConnection user, WebSocketReceiveResult? payload)
    {
        Console.WriteLine("WebsocketService.HandleCloseSent");
        return Task.CompletedTask;
    }

    private Task HandleClosed(
        UserConnection user, WebSocketReceiveResult? payload)
    {
        Console.WriteLine("WebsocketService.HandleClosed");
        return Task.CompletedTask;
    }

    private Task HandleAborted(
        UserConnection user, WebSocketReceiveResult? payload)
    {
        Console.WriteLine("WebsocketService.HandleAborted");
        return user.Destroy();
    }

    public async Task<WebSocketReceiveResult>? GetPayload(WebSocket ws, byte[] buffer)
    {
        try
        {
            return await ws.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}
