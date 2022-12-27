using static BlazorApp1ServerWithApi.Common.EventBus;

namespace BlazorApp1ServerWithApi.Common
{
    public interface IEventBus
    {
        //public event QueryReceivedEventHandler? QueryReceived;
        public event EventHandler<CounterRequestReceivedEventArgs>? QueryReceived;
        public void Push();
        public void Push(int count);

    }

    public class EventBus : IEventBus
    {
        //public delegate Task QueryReceivedEventHandler(object source, QueryReceivedEventArgs eventArgs);
        //public event QueryReceivedEventHandler? QueryReceived;

        public event EventHandler<CounterRequestReceivedEventArgs>? QueryReceived;

        protected virtual void OnQueryReceived()
        {
            if(QueryReceived != null)
                QueryReceived(this, null);    
        }

        public void Push()
        {
            OnQueryReceived();
        }

        public virtual void Push(int count)
        {
            //if (QueryReceived != null)
            //    QueryReceived(this, new QueryReceivedEventArgs { Count = count});

            QueryReceived?.Invoke(this, new CounterRequestReceivedEventArgs { Count = count });
        }
    }
}
