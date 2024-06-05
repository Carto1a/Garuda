using Client.Handlers.Websockets.Receive;
using Client.Handlers.Websockets.Receive.Interfaces;
using Client.Handlers.Websockets.Send;
using Client.Handlers.Websockets.Send.Interfaces;
using Client.Services;
using Client.Services.Intefaces;
/* using Client.TUI.Components; */
/* using Client.TUI.Components.Containers; */
/* using Client.TUI.Core; */
using Microsoft.Extensions.DependencyInjection;
using TermUI.Core;
using TermUI.Core.Keymaps;

/* var serviceCollection = new ServiceCollection(); */
/* serviceCollection.AddSingleton<IPayloadSendHandler, PayloadSendHandler>(); */
/* serviceCollection.AddSingleton<IPayloadReceiveHandler, PayloadReceiveHandler>(); */
/* serviceCollection.AddSingleton<IWebsocketService, WebsocketService>(); */

/* var provider = serviceCollection.BuildServiceProvider(); */

/* var WebsocketService = provider.GetService<IWebsocketService>(); */

/* var tuiManager = new TUIManager(new TUIRenderer()); */
/* tuiManager.Initialize(); */

/* var mainContainer = new VerticalContainer(); */
/* var textComponent = new TextComponent("Hello World"); */
/* var textComponent2 = new TextComponent("Hello World2"); */
/* var textComponent3 = new TextComponent("0"); */
/* var textComponent4 = new TextComponent("0"); */

/* var cursorposleft = new TextComponent("0"); */
/* var cursorpostop = new TextComponent("0"); */
/* var consoleleft = new TextComponent("0"); */
/* var consoletop = new TextComponent("0"); */

var keymap0 = new TUIKeymap()
    .SetKeys("gl")
    .SetAction(() =>
        Console.WriteLine("Hello World"));

var manager = new TUIManager();
manager.Initialize();

/* manager._keymap.AddKeymap(keymap0); */

manager.MainLoop();

/* tuiManager.AddComponent(mainContainer); */
/* mainContainer.Add(textComponent); */
/* mainContainer.Add(textComponent2); */
/* mainContainer.Add(new TextComponent( */
/*     "Hellfjlsdkajflsdkklkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkko World3sdklfjksljfklsjfkjsdklfjsdklfjsdklfjsdkljflsdkjfklsdjfkdskfsdklfjdskljfklsdjfkdsjfksdjkfsjdklfjsdklfjskldjfklsdjfkjdsklj")); */
/* mainContainer.Add(new TextComponent("Hello World4")); */
/* mainContainer.Add(new TextComponent("Hello World5")); */
/* mainContainer.Add(new TextComponent("Hello World6")); */
/* mainContainer.Add(new TextComponent("Hello World7")); */
/* mainContainer.Add(new TextComponent("Hello World8")); */
/* mainContainer.Add(new TextComponent("Hello World9")); */
/* mainContainer.Add(textComponent4); */
/* mainContainer.Add(cursorposleft); */
/* mainContainer.Add(cursorpostop); */
/* mainContainer.Add(consoleleft); */
/* mainContainer.Add(consoletop); */
/* /1* mainContainer.Add(textComponent3); *1/ */

/* tuiManager.InitializeDebug( */
/*     textComponent3, */
/*     textComponent4); */
/* tuiManager.InitializeRender(); */

/* Task task = new Task(() => */
/* { */
/*     ulong i = 0; */
/*     while (true) */
/*     { */
/*         i += 1; */
/*         textComponent.Update($"Hello World {i}"); */
/*         Thread.Sleep(1); */
/*     } */
/* }); */

/* Task task2 = new Task(() => */
/* { */
/*     while (true) */
/*     { */
/*         cursorposleft.Update($"CursorLeft: {Console.CursorLeft}/ Manager CursorLeft: {tuiManager.CursorLeft}"); */
/*         cursorpostop.Update($"CursorTop: {Console.CursorTop}/ Manager CursorTop: {tuiManager.CursorTop}"); */
/*         consoleleft.Update($"ConsoleLeft: {Console.WindowWidth}"); */
/*         consoletop.Update($"ConsoleTop: {Console.WindowHeight}"); */
/*         Thread.Sleep(10); */
/*     } */
/* }); */

/* /1* task.Start(); *1/ */
/* task2.Start(); */

/* task2.Wait(); */

/* var t = (char)Console.ReadKey(true).Key; */

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

