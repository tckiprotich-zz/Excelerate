using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetworkAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeControllers : ControllerBase
    {
        [HttpGet("in")]
        public IActionResult Home ()
        {
            return Ok ("in");
        }
    }
}