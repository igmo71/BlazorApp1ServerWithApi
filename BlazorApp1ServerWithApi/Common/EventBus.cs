using static BlazorApp1ServerWithApi.Common.EventBus;

namespace BlazorApp1ServerWithApi.Common
{
    public interface IEventBus
    {
        //public event QueryReceivedEventHandler? QueryReceived;
        public event EventHandler<CounterRequestReceivedEventArgs>? CounterRequestReceived;
        public void Push();
        public void PushCounterRequestReceived(int count);

    }

    public class EventBus : IEventBus
    {
        //public delegate Task QueryReceivedEventHandler(object source, QueryReceivedEventArgs eventArgs);
        //public event QueryReceivedEventHandler? QueryReceived;

        public event EventHandler<CounterRequestReceivedEventArgs>? CounterRequestReceived;

        protected virtual void OnQueryReceived()
        {
            if(CounterRequestReceived != null)
                CounterRequestReceived(this, null);    
        }

        public void Push()
        {
            OnQueryReceived();
        }

        public virtual void PushCounterRequestReceived(int count)
        {
            //if (QueryReceived != null)
            //    QueryReceived(this, new QueryReceivedEventArgs { Count = count});

            CounterRequestReceived?.Invoke(this, new CounterRequestReceivedEventArgs { Count = count });
        }
    }
}
