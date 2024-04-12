using System.Net;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Interfaces;

namespace SuaAplicacao.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WebSocketController : ControllerBase
{
    private readonly IWebsocketService _wsService;
    public WebSocketController(
        IWebsocketService wsService)
    {
        _wsService = wsService;
    }

    [HttpGet("/ws")]
    public async Task GetWebSocket()
    {
        if (!HttpContext.WebSockets.IsWebSocketRequest)
        {
            HttpContext.Response.StatusCode =
                (int)HttpStatusCode.BadRequest;
            return;
        }

        WebSocket webSocket =
            await HttpContext.WebSockets.AcceptWebSocketAsync();

        await _wsService.OpenWebsocket(webSocket);
    }
}

