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

UserSimpleInfo? user = null;
Console.Write("Coloque seu username: ");
var username = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(username))
{
    user = new UserSimpleInfo(Guid.NewGuid(), username);
}

WebsocketService.Handle(user).Wait();
