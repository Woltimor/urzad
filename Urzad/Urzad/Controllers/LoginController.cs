using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urzad.Responses;
using Urzad.Services;

namespace Urzad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServ _loginServ;

        public LoginController(ILoginServ loginServ)
        {
            _loginServ = loginServ;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new LoginResponse();
            try
            {
                response = await _loginServ.GetAsync(id);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAsync([FromBody]LoginResponse loginResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ret = await _loginServ.insertLogin(loginResponse);
            return Ok(ret);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]LoginResponse loginResponse) {

            var ret = await _loginServ.UpdateLogin(id, loginResponse);
            return Ok(ret);
        }
        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}