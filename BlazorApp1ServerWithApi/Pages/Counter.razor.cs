using BlazorApp1ServerWithApi.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1ServerWithApi.Pages
{
    public partial class Counter
    {
        [Inject]
        public IEventBus? EventBus { get; set; }

        private int currentCount = 0;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (EventBus is EventBus eventBus)
                eventBus.CounterRequestReceived += async (source, eventArgs) => await OnCounterRequestReceivedAsync(source, eventArgs);
        }

        private void IncrementCount(int count = 1)
        {
            currentCount += count;
        }

        private async Task OnCounterRequestReceivedAsync(object? source, CounterRequestReceivedEventArgs eventArgs)
        {
            if (eventArgs is not null)
            {
                await InvokeAsync(() =>
                {
                    IncrementCount(eventArgs.Count);
                    StateHasChanged();
                });
            }
        }
    }
}
