using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Career_Connect.Api.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectionMessageController : ControllerBase
    {
        private readonly ICreateConnectionService _createConnectionService;

        public ConnectionMessageController(ICreateConnectionService createConnectionService)
        {
            _createConnectionService = createConnectionService;
        }

        /// <summary>
        /// Creates a new connection/networking message.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateConnection(NetworkModel newConnection)
        {
            var response = await _createConnectionService.CreateConnection(newConnection);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}