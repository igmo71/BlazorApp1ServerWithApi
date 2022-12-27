namespace BlazorApp1ServerWithApi.Common
{
    public interface IEventBus
    {
        public event EventHandler<CounterRequestReceivedEventArgs>? CounterRequestReceived;
        public void PushCounterRequestReceived(int count);
    }

    public class EventBus : IEventBus
    { 
        public event EventHandler<CounterRequestReceivedEventArgs>? CounterRequestReceived;

        public virtual void PushCounterRequestReceived(int count)
        {

            CounterRequestReceived?.Invoke(this, new CounterRequestReceivedEventArgs { Count = count });
        }
    }
}
