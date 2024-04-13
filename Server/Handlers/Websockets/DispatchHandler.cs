using Domain.Entities.Payloads.Dispatch;
using Domain.Enums.Payloads;
using Server.Handlers.Websockets.Intefaces;

namespace Server.Handlers.Websockets;
public class DispatchHandler
: IDispatchHandler
{
    private readonly IDictionary<string, Func<string, Task>> _handler;
    public DispatchHandler()
    {
        _handler = new Dictionary<string, Func<string, Task>>
        {
            [nameof(DispatchEvents.MESSAGE_CREATED)] = MessageCreated,
            [nameof(DispatchEvents.MESSAGE_UPDATED)] = MessageUpdated,
            [nameof(DispatchEvents.MESSAGE_DELETED)] = MessageDeleted,
            [nameof(DispatchEvents.JOINED)] = Joined,
            [nameof(DispatchEvents.LEFTED)] = Lefted,
            [nameof(DispatchEvents.DISCONNECTED)] = Disconnected
        };
    }

    public Task Handle(string data)
    {
        Console.WriteLine("DispatchHandler.Handle");
        if (data == null)
            throw new ArgumentNullException();

        return Task.CompletedTask;
        /* if (data.event_name == null) */
        /*     throw new ArgumentNullException(); */

        /* var func = _handler[data.event_name]; */
        /* if (func == null) */
        /*     throw new NotImplementedException(); */

        /* return func(data); */
    }

    public Task Disconnected(string data)
    {
        Console.WriteLine("DispatchHandler.Disconnected");
        return Task.CompletedTask;
    }

    public Task Joined(string data)
    {
        Console.WriteLine("DispatchHandler.Joined");
        return Task.CompletedTask;
    }

    public Task Lefted(string data)
    {
        Console.WriteLine("DispatchHandler.Lefted");
        return Task.CompletedTask;
    }

    public Task MessageCreated(string data)
    {
        Console.WriteLine("DispatchHandler.MessageCreated");
        return Task.CompletedTask;
    }

    public Task MessageDeleted(string data)
    {
        Console.WriteLine("DispatchHandler.MessageDeleted");
        return Task.CompletedTask;
    }

    public Task MessageUpdated(string data)
    {
        Console.WriteLine("DispatchHandler.MessageUpdated");
        return Task.CompletedTask;
    }
}
