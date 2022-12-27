using BlazorApp1ServerWithApi.Common;
using BlazorApp1ServerWithApi.Servicves;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1ServerWithApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly IEventBus _eventBus;
        private readonly ICounterService _counterService;

        public CounterController(IEventBus eventBus, ICounterService counterService)
        {
            _eventBus = eventBus;
            _counterService = counterService;
        }

        [HttpGet]
        public IActionResult Get(int count)
        {
            _eventBus.PushCounterRequestReceived(count);
            return Ok("Hello, World!");
        }

        [HttpPost]
        public IActionResult Post(CounterDto counterDto)
        {
            CounterVm counterVm = _counterService.SetCounterVm(counterDto);
            return Ok(counterVm);
        }
    }
}
