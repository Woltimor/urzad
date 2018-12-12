using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Urzad.Data.Models;
using Urzad.Responses;
using Urzad.Services;

namespace Urzad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class PersonalAtController : Controller
        {
            private readonly IPersonalAtributesServ _atributesServ;

            public PersonalAtController(IPersonalAtributesServ personalServ)
            {
                _atributesServ = personalServ;
            }
            [HttpGet]
            public async Task<IActionResult> Get()
            {


                List<PersonalAtributesResponse> list = new List<PersonalAtributesResponse>();
                try
                {
                    list = await _atributesServ.GetAsync();
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
                var response = new PersonalAtributesResponse();
                try
                {
                    response = await _atributesServ.GetAsync(id);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
                return Ok(response);
            }
            [HttpPost]
            public void Post([FromBody]string value) { }
            [HttpPut("{id}")]
            public void Put(int id, [FromBody]string value) { }
            [HttpDelete("{id}")]
            public void Delete(int id) { }
        }
    }

