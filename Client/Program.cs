using System.Diagnostics;
using Client.Handlers.Websockets.Receive;
using Client.Handlers.Websockets.Receive.Interfaces;
using Client.Handlers.Websockets.Send;
using Client.Handlers.Websockets.Send.Interfaces;
using Client.Services;
using Client.Services.Intefaces;
using Domain.Entities.Servers.Users.Informations;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IPayloadSendHandler, PayloadSendHandler>();
serviceCollection.AddSingleton<IPayloadReceiveHandler, PayloadReceiveHandler>();
serviceCollection.AddSingleton<IWebsocketService, WebsocketService>();

var provider = serviceCollection.BuildServiceProvider();

var WebsocketService = provider.GetService<IWebsocketService>();
/* Console.CursorVisible = false; */
Console.Clear();
var i = 0;
while (true)
{
    var (cursorLeft, cursorTop) = Console.GetCursorPosition();
    var key = Console.ReadKey(true);
    /* Console.Write($"\\{key.KeyChar}"); */
    if (key.KeyChar == 'j')
    {
        Console.SetCursorPosition(cursorLeft, cursorTop+1);
    }
    /* Console.Write($"{key.KeyChar}"); */
    /* Console.Write("\r"); */
    /* Console.Write($"i: {i++}"); */
    /* Stopwatch sw = new Stopwatch(); */
    /* sw.Start(); */
    /* Thread.Sleep(1); */
    /* // Do Work */
    /* sw.Stop(); */

    /* Console.Write("Elapsed time: {0}", sw.Elapsed.TotalMilliseconds); */
    /* Console.Write("\r"); */
    /* if (sw.Elapsed.TotalMilliseconds < 16) */
    /*     Thread.Sleep(16-(int)sw.Elapsed.TotalMilliseconds); */

    /* Console.Write($"i: {i++}"); */
}
/* UserSimpleInfo? user = null; */
/* Console.Write("Coloque seu username: "); */
/* var username = Console.ReadLine(); */
/* if (!string.IsNullOrWhiteSpace(username)) */
/* { */
/*     user = new UserSimpleInfo(Guid.NewGuid(), username); */
/* } */

/* WebsocketService.Handle(user).Wait(); */

