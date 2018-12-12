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
    public class ManagementController : ControllerBase
    {
        private readonly IManagementServ _magagementServ;
        public ManagementController(IManagementServ managementServ)
        {
            _magagementServ = managementServ;
        }
        [HttpPost("typy")]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAsync([FromBody]ManagementResponse managementResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ret = await _magagementServ.insert(managementResponse);
            return Ok(ret);
        }
        [HttpPost("kategorie")]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAsync([FromBody] KategoriaOferty kat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ret = await _magagementServ.insert(kat);
            return Ok(ret);
        }
        [HttpPost("oferty")]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAsync([FromBody] Oferty oferty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ret = await _magagementServ.insert(oferty);
            return Ok(ret);
        }
        [HttpPost("kwalifikacje")]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAsync([FromBody] PosiadaneKwalifikacjes kwalifikacje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ret = await _magagementServ.insert(kwalifikacje);
            return Ok(ret);
        }


    }
}