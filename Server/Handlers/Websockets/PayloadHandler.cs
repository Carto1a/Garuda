using Domain.Entities.Payloads;
using Domain.Entities.Payloads.Dispatch;
using Domain.Entities.Payloads.Invoke;
using Server.Handlers.Websockets.Intefaces;

namespace Server.Handlers.Websockets;
public class PayloadHandler
: IPayloadHandler
{
    private readonly IInvokeHandler _invokeHandler;
    private readonly IDispatchHandler _dispatchHandler;
    private readonly IList<Func<Payload<object>, Task>> _handlers;

    public PayloadHandler(
        IInvokeHandler invokeHandler,
        IDispatchHandler dispatchHandler)
    {
        _invokeHandler = invokeHandler;
        _dispatchHandler = dispatchHandler;
        _handlers = new List<Func<Payload<object>, Task>>
        {
            Dispatch,
            Invoke,
            Heartbeat,
            Identify,
            Hello,
            HeartbeatAck,
            Disconnect,
        };
    }

        public async Task Handle(Payload<object> payload)
        {
            var op = payload.op;

            var func = _handlers[(int)op];
            if (func == null)
                throw new NotImplementedException();

            await func(payload);
        }

        public Task Invoke(Payload<object> payload)
        {
            var data = payload.d as Invoke;
            if (data == null)
                throw new ArgumentNullException();

            return _invokeHandler.Handle(data);
        }

        public Task Dispatch(Payload<object> payload)
        {
            var data = payload.d as Dispatch;
            if (data == null)
                throw new ArgumentNullException();

        return _dispatchHandler.Handle(data);
    }

    public Task Disconnect(Payload<object> payload)
    {
        Console.WriteLine("PayloadHandler.Disconnect");
        return Task.CompletedTask;
    }

    public Task Heartbeat(Payload<object> payload)
    {
        Console.WriteLine("PayloadHandler.Heartbeat");
        return Task.CompletedTask;
    }

    public Task HeartbeatAck(Payload<object> payload)
    {
        Console.WriteLine("PayloadHandler.HeartbeatAck");
        return Task.CompletedTask;
    }

    public Task Hello(Payload<object> payload)
    {
        Console.WriteLine("PayloadHandler.Hello");
        return Task.CompletedTask;
    }

    public Task Identify(Payload<object> payload)
    {
        Console.WriteLine("PayloadHandler.Identify");
        return Task.CompletedTask;
    }
}
