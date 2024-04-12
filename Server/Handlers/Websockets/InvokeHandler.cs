using Domain.Entities.Payloads.Invoke;
using Domain.Enums.Payloads;
using Server.Handlers.Websockets.Intefaces;

namespace Server.Handlers.Websockets;
public class InvokeHandler
: IInvokeHandler
{
    private readonly IDictionary<string, Func<Invoke, Task>> _handler;
    public InvokeHandler()
    {
        _handler = new Dictionary<string, Func<Invoke, Task>>
        {
            [nameof(InvokeEvents.MESSAGE_CREATE)] = MessageCreate,
            [nameof(InvokeEvents.MESSAGE_UPDATE)] = MessageUpdate,
            [nameof(InvokeEvents.MESSAGE_DELETE)] = MessageDelete,
            [nameof(InvokeEvents.JOIN)] = Join,
            [nameof(InvokeEvents.LEAVE)] = Leave,
            [nameof(InvokeEvents.DISCONNECT)] = Disconnect
        };
    }

    public Task Handle(Invoke data)
    {
        Console.WriteLine("InvokeHandler.Handle");
        if (data == null)
            throw new ArgumentNullException();
        if (data.event_name == null)
            throw new ArgumentNullException();

        var func = _handler[data.event_name];
        if (func == null)
            throw new NotImplementedException();

        return func(data);
    }

    public Task Disconnect(Invoke data)
    {
        Console.WriteLine("InvokeHandler.Disconnect");
        return Task.CompletedTask;
    }

    public Task Join(Invoke data)
    {
        Console.WriteLine("InvokeHandler.Join");
        return Task.CompletedTask;
    }

    public Task Leave(Invoke data)
    {
        Console.WriteLine("InvokeHandler.Leave");
        return Task.CompletedTask;
    }

    public Task MessageCreate(Invoke data)
    {
        Console.WriteLine("InvokeHandler.MessageCreate");
        return Task.CompletedTask;
    }

    public Task MessageDelete(Invoke data)
    {
        Console.WriteLine("InvokeHandler.MessageDelete");
        return Task.CompletedTask;
    }

    public Task MessageUpdate(Invoke data)
    {
        Console.WriteLine("InvokeHandler.MessageUpdate");
        return Task.CompletedTask;
    }
}

