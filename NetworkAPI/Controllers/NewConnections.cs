global using NetworkAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetworkAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class NewConnections : ControllerBase
    {
        private readonly INewConnection _newConnection;

        public NewConnections(INewConnection newConnection)
        {
            _newConnection = newConnection;
        }

        [HttpPost]
[Route("new-connection")]
public async Task<IActionResult> CreateConnection([FromBody] NetworkModel newConnection)
{
    var response = await _newConnection.CreateConnection(newConnection);
    if (response.Success)
    {
        return Ok(response);
    }
    else
    {
        return BadRequest(response);
    }
}
    }
}