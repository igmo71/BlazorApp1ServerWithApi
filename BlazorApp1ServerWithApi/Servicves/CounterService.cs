namespace BlazorApp1ServerWithApi.Servicves
{
    public interface ICounterService : IObservable<CounterVm>
    {
        public CounterVm SetCounterVm(CounterDto counterDto);
    }

    public class CounterService : ICounterService
    {
        private CounterVm counterVm;
        private List<IObserver<CounterVm>> observers;

        public CounterService()
        {
            counterVm = new CounterVm();
            observers = new List<IObserver<CounterVm>>();
        }

        public IDisposable Subscribe(IObserver<CounterVm> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);

                observer.OnNext(counterVm);
            }

            return new Unsubscriber<CounterVm>(observers, observer);
        }

        public CounterVm SetCounterVm(CounterDto counterDto)
        {
            var counterVm = CounterVm
                .CreateBuilder()
                .SetCount(counterDto.Count)
                .Build();

            foreach (var observer in observers)
            {
                observer.OnNext(counterVm);
            }

            return counterVm;
        }
    }
}
