using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> log;

        public LoginController(ILogger<LoginController> logger)
        {
            log = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            log.LogInformation("####################  login in login controller ####################");
            return Ok("Hello from LoginController");
        }
    }
}
