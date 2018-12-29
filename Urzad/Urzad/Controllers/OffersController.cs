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
    public class OffersController : ControllerBase
    {
         private readonly IOffersServ _offersServ;

            public OffersController(IOffersServ offersServ)
            {
            _offersServ = offersServ;

            }
            [HttpGet("chujowa")]
            public async Task<IActionResult> Get()
            {


                List<OffersResponse> list = new List<OffersResponse>();
                try
                {
                    list = await _offersServ.GetAsync();
                }
                catch (Exception Ex)

                {
                    return BadRequest(Ex);
                }
                return Ok(list);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
            List<OffersResponse> list = new List<OffersResponse>();
            try
                {
                    list = await _offersServ.GetAsync(id);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
                return Ok(list);
            }
            [HttpPost]
            public void Post([FromBody]string value) { }
            [HttpPut("{id}")]
            public void Put(int id, [FromBody]string value) { }
            [HttpDelete("{id}")]
            public void Delete(int id) { }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {


            List<Oferty> list = new List<Oferty>();
            try
            {
                list = await _offersServ.GetAllAsync();
            }
            catch (Exception Ex)

            {
                return BadRequest(Ex);
            }
            return Ok(list);
        }
    }
}