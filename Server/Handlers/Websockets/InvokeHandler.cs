using System.Text.Json;
using Domain.Entities.Payloads.Invoke;
using Domain.Enums.Payloads;
using Server.Handlers.Websockets.Intefaces;

namespace Server.Handlers.Websockets;
public class InvokeHandler
: IInvokeHandler
{
    private readonly IDictionary<string, Func<string, Task>> _handler;
    public InvokeHandler()
    {
        _handler = new Dictionary<string, Func<string, Task>>
        {
            [nameof(InvokeEvents.MESSAGE_CREATE)] = MessageCreate,
            [nameof(InvokeEvents.MESSAGE_UPDATE)] = MessageUpdate,
            [nameof(InvokeEvents.MESSAGE_DELETE)] = MessageDelete,
            [nameof(InvokeEvents.JOIN)] = Join,
            [nameof(InvokeEvents.LEAVE)] = Leave,
            [nameof(InvokeEvents.DISCONNECT)] = Disconnect
        };
    }

    public Task Handle(string data)
    {
        Console.WriteLine("InvokeHandler.Handle");
        string eventName;
        using (JsonDocument document = JsonDocument.Parse(data))
        {
            eventName = document.RootElement.GetProperty("event_name").GetString()
                ?? throw new ArgumentNullException();
        }

        var func = _handler[eventName];
        if (func == null)
            throw new NotImplementedException();

        return func(data);
    }

    public Task Disconnect(string data)
    {
        Console.WriteLine("InvokeHandler.Disconnect");
        return Task.CompletedTask;
    }

    public Task Join(string data)
    {
        Console.WriteLine("InvokeHandler.Join");
        return Task.CompletedTask;
    }

    public Task Leave(string data)
    {
        Console.WriteLine("InvokeHandler.Leave");
        return Task.CompletedTask;
    }

    public Task MessageCreate(string data)
    {
        Console.WriteLine("InvokeHandler.MessageCreate");
        return Task.CompletedTask;
    }

    public Task MessageDelete(string data)
    {
        Console.WriteLine("InvokeHandler.MessageDelete");
        return Task.CompletedTask;
    }

    public Task MessageUpdate(string data)
    {
        Console.WriteLine("InvokeHandler.MessageUpdate");
        return Task.CompletedTask;
    }
}

