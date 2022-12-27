using BlazorApp1ServerWithApi.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BlazorApp1ServerWithApi.Controllers.CounterController;

namespace BlazorApp1ServerWithApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly IEventBus _eventBus;

        public CounterController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [HttpGet]
        public IActionResult Get(int count)
        {
            _eventBus.Push(count);
            return Ok("Hello, World!");
        }
    }
}
