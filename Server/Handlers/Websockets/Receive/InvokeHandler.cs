using Domain.Entities.Payloads;
using Domain.Enums.Payloads;
using Server.Handlers.Websockets.Receive.Interfaces;

namespace Server.Handlers.Websockets.Receive;
public class InvokeHandler
: IInvokeHandler
{
    private readonly IDictionary<string, Func<Payload<object>, Task>> _handler;
    public InvokeHandler()
    {
        _handler = new Dictionary<string, Func<Payload<object>, Task>>
        {
            [nameof(InvokeEvents.MESSAGE_CREATE)] = MessageCreate,
            [nameof(InvokeEvents.MESSAGE_UPDATE)] = MessageUpdate,
            [nameof(InvokeEvents.MESSAGE_DELETE)] = MessageDelete,
            [nameof(InvokeEvents.JOIN)] = Join,
            [nameof(InvokeEvents.LEAVE)] = Leave,
        };
    }

    public Task Handle(Payload<object> payload)
    {
        Console.WriteLine("InvokeHandler.Handle");

        var func = _handler[payload.t];
        if (func == null)
            throw new NotImplementedException();

        return func(payload);
    }

    public Task Join(Payload<object> payload)
    {
        Console.WriteLine("InvokeHandler.Join");
        return Task.CompletedTask;
    }

    public Task Leave(Payload<object> payload)
    {
        Console.WriteLine("InvokeHandler.Leave");
        return Task.CompletedTask;
    }

    public Task MessageCreate(Payload<object> payload)
    {
        Console.WriteLine("InvokeHandler.MessageCreate");
        return Task.CompletedTask;
    }

    public Task MessageDelete(Payload<object> payload)
    {
        Console.WriteLine("InvokeHandler.MessageDelete");
        return Task.CompletedTask;
    }

    public Task MessageUpdate(Payload<object> payload)
    {
        Console.WriteLine("InvokeHandler.MessageUpdate");
        return Task.CompletedTask;
    }
}

