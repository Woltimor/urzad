using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Urzad.Data.Models;
using Urzad.Services;

namespace Urzad.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthServ _authServ;
        /*
        public AuthController(IAuthServ authServ)
        {
            _authServ = authServ;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]Login loginParam)
        {
            var login = await _authServ.Authenticate(loginParam.Login1, loginParam.Hasło);

            if (login == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(login);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _authServ.GetAll();
            return Ok(users);
        }
        */
    }
}