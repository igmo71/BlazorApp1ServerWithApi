using BlazorApp1ServerWithApi.Servicves;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1ServerWithApi.Pages
{
    public partial class Counter2 : IObserver<CounterVm>, IDisposable
    {
        [Inject]
        public ICounterService? CounterService { get; set; }

        private IDisposable? unsubscriber;

        //private int currentCount = 0;
        CounterVm counterVm = new CounterVm { CurrentCount = 0 };

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SubscribeCounterService();
        }

        private void SubscribeCounterService()
        {
            unsubscriber = CounterService?.Subscribe(this);
        }

        private void IncrementCount(int count = 1)
        {
            counterVm.CurrentCount += count;
        }

        public void OnCompleted()
        {
            counterVm = new();
            Dispose();
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnNext(CounterVm value)
        {
            InvokeAsync(() =>
            {
                IncrementCount(value.Count);
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            unsubscriber?.Dispose();
        }
    }
}
