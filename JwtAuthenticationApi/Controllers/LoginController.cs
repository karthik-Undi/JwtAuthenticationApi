using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthenticationApi.Model;
using JwtAuthenticationApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthenticationController));
        private readonly IAuthenticationManager manager;

        private readonly JwtAuthenticationContext context;
        public LoginController(IAuthenticationManager manager)
        {
            this.manager = manager;
        }


        [HttpGet]
        public string Get()
        {
            return "Hello";
        }



        [AllowAnonymous]
        [HttpPost("AuthenicateUser")]
        public IActionResult AuthenticateUser([FromBody] LoginDetails loginDetails)
        {
            //_log4net.Info(" Http Authentication request Initiated");
            var token = manager.Authenticate(loginDetails.Username, loginDetails.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

    }
}
