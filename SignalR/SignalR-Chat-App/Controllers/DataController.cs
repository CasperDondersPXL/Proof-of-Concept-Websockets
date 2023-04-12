using Microsoft.AspNetCore.Mvc;
using SignalR_Chat_App.Helpers;

namespace SignalR_Chat_App.Controllers
{
    [Route("data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataHandler _dataHandler;

        public DataController(DataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        [HttpGet]
        public async Task<IActionResult> FlushAndSave()
        {
            await _dataHandler.Flush();
            return Ok();
        }
    }
}
