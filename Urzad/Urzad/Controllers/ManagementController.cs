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
        private readonly IManagementServ _managementServ;
        public ManagementController(IManagementServ managementServ)
        {
            _managementServ = managementServ;
        }
        [HttpPost("typy")]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAsync([FromBody]ManagementResponse managementResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ret = await _managementServ.Insert(managementResponse);
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

            var ret = await _managementServ.Insert(kat);
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

            var ret = await _managementServ.Insert(oferty);
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

            var ret = await _managementServ.Insert(kwalifikacje);
            return Ok(ret);
        }
        [HttpPost("wniosek")]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateAsync([FromBody] ProposalResponse proposal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ret = await _managementServ.Insert(proposal);
            return Ok(ret);
        }
        [HttpPut("typy/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]ManagementResponse types)
        {

            var ret = await _managementServ.UpdateType(id, types);
            return Ok(ret);
        }
        [HttpPut("kategorie/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]CategoryResponse categories)
        {

            var ret = await _managementServ.UpdateCategory(id, categories);
            return Ok(ret);
        }
        [HttpPut("oferty/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]OfferResponse offers)
        {

            var ret = await _managementServ.UpdateOffer(id, offers);
            return Ok(ret);
        }
        [HttpPut("uprawnienia/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]RolesResponse roles)
        {

            var ret = await _managementServ.UpdateRoles(id, roles);
            return Ok(ret);
        }
        [HttpGet("typy")]
        public async Task<IActionResult> GetType()
        {


            List<ManagementResponse> list = new List<ManagementResponse>();
            try
            {
                list = await _managementServ.GetTypeAsync();
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
                list = await _managementServ.GetCategoryAsync();
            }
            catch (Exception Ex)

            {
                return BadRequest(Ex);
            }
            return Ok(list);
        }
        [HttpGet("kwalifikacje")]
        public async Task<IActionResult> GetQualifications()
        {


            List<QualificationResponse> list = new List<QualificationResponse>();
            try
            {
                list = await _managementServ.GetQualificationsAsync();
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
                list = await _managementServ.GetOfferAsync();
            }
            catch (Exception Ex)

            {
                return BadRequest(Ex);
            }
            return Ok(list);
        }
        [HttpGet("typy/kategorie")]
        public async Task<IActionResult> GetTypeCategory()
        {


            List<TypeCategoryResponse> list = new List<TypeCategoryResponse>();
            try
            {
                list = await _managementServ.GetTypeCategoryAsync();
            }
            catch (Exception Ex)

            {
                return BadRequest(Ex);
            }
            return Ok(list);
        }
        [HttpGet("kategorie/oferty")]
        public async Task<IActionResult> GetCategoryOffer()
        {


            List<CategoryOfferResponse> list = new List<CategoryOfferResponse>();
            try
            {
                list = await _managementServ.GetCategoryOfferAsync();
            }
            catch (Exception Ex)

            {
                return BadRequest(Ex);
            }
            return Ok(list);
        }

    }
}