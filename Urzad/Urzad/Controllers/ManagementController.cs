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
        [HttpPut("typy/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]ManagementResponse types)
        {

            var ret = await _magagementServ.UpdateType(id, types);
            return Ok(ret);
        }
        [HttpPut("kategorie/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]CategoryResponse categories)
        {

            var ret = await _magagementServ.UpdateCategory(id, categories);
            return Ok(ret);
        }
        [HttpPut("oferty/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]OfferResponse offers)
        {

            var ret = await _magagementServ.UpdateOffer(id, offers);
            return Ok(ret);
        }
        [HttpGet("typy")]
        public async Task<IActionResult> GetType()
        {


            List<ManagementResponse> list = new List<ManagementResponse>();
            try
            {
                list = await _magagementServ.GetTypeAsync();
            }
            catch (Exception Ex)

            {
                return BadRequest(Ex);
            }
            return Ok(list);
        }
        [HttpGet("kategorie")]
        public async Task<IActionResult> GetCategory()
        {


            List<CategoryResponse> list = new List<CategoryResponse>();
            try
            {
                list = await _magagementServ.GetCategoryAsync();
            }
            catch (Exception Ex)

            {
                return BadRequest(Ex);
            }
            return Ok(list);
        }
        [HttpGet("oferty")]
        public async Task<IActionResult> GetOffer()
        {


            List<OfferResponse> list = new List<OfferResponse>();
            try
            {
                list = await _magagementServ.GetOfferAsync();
            }
            catch (Exception Ex)

            {
                return BadRequest(Ex);
            }
            return Ok(list);
        }


    }
}