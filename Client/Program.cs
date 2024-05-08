using Client.Handlers.Websockets.Receive;
using Client.Handlers.Websockets.Receive.Interfaces;
using Client.Handlers.Websockets.Send;
using Client.Handlers.Websockets.Send.Interfaces;
using Client.Services;
using Client.Services.Intefaces;
using Client.TUI.Components;
using Client.TUI.Core;
using Microsoft.Extensions.DependencyInjection;

/* var serviceCollection = new ServiceCollection(); */
/* serviceCollection.AddSingleton<IPayloadSendHandler, PayloadSendHandler>(); */
/* serviceCollection.AddSingleton<IPayloadReceiveHandler, PayloadReceiveHandler>(); */
/* serviceCollection.AddSingleton<IWebsocketService, WebsocketService>(); */

/* var provider = serviceCollection.BuildServiceProvider(); */

/* var WebsocketService = provider.GetService<IWebsocketService>(); */

var tuiManager = new TUIManager(new TUIRenderer());
tuiManager.Initialize();

var textComponent = new TextComponent("Hello World");
var textComponent2 = new TextComponent("Hello World2", 1, 0);


tuiManager.AddComponent(textComponent);
tuiManager.AddComponent(textComponent2);
tuiManager.AddComponent(new TextComponent("Hello World2", 1, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 2, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 3, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 4, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 5, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 6, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 7, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 8, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 9, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 10, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 11, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 12, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 13, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 14, 0));
tuiManager.AddComponent(new TextComponent("Hello World2", 15, 0));
/* tuiManager.AddComponent(new TextComponent("Hello World2", 16, 0)); */

tuiManager.InitializeRender();

Task task = new Task(() =>
{
    ulong i = 0;
    while (true)
    {
        i += 1;
        textComponent.Update($"Hello World {i}");
    }
});

Task task2 = new Task(() =>
{
    ulong i = 0;
    while (true)
    {
        i += 1;
        textComponent2.Update($"Hello World {i}");
    }
});

task.Start();
task2.Start();

task.Wait();
task2.Wait();

/* { */
/*     Console.SetCursorPosition(cursorLeft, cursorTop+1); */
/* } */
/* Console.Write($"{key.KeyChar}"); */
/* Stopwatch sw = new Stopwatch(); */
/* sw.Start(); */
/* // Do Work */
/* sw.Stop(); */

/* Console.Write("Elapsed time: {0}", sw.Elapsed.TotalMilliseconds); */
/* Console.Write("\r"); */
/* if (sw.Elapsed.TotalMilliseconds < 16) */
/*     Thread.Sleep(16-(int)sw.Elapsed.TotalMilliseconds); */

/* Console.Write($"i: {i++}"); */
/* UserSimpleInfo? user = null; */
/* Console.Write("Coloque seu username: "); */
/* var username = Console.ReadLine(); */
/* if (!string.IsNullOrWhiteSpace(username)) */
/* { */
/*     user = new UserSimpleInfo(Guid.NewGuid(), username); */
/* } */

/* WebsocketService.Handle(user).Wait(); */

