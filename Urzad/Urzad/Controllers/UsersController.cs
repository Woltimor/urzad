using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Urzad.Services;
using Urzad.Helpers;
using Urzad.Responses;
using Urzad.Data.Models;
using AutoMapper;

namespace Urzad.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserServ _userServ;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserServ userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userServ = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserResponse userResponse)
        {
            var user = _userServ.Authenticate(userResponse.Login, userResponse.Haslo);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.IdOsoby.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                IdOsoby = user.IdOsoby,
                Uprawnienia = user.Uprawnienia,
                Login = user.Login,
                Imie = user.Imie,
                Nazwisko = user.Nazwisko,
                Pesel = user.Pesel,
                EMail = user.Email,
                DataUrodzenia = user.DataUrodzenia,
                Wyksztalcenie = user.Wyksztalcenie,
                Plec = user.Plec,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserResponse userResponse)
        {
            // map dto to entity
            var user = _mapper.Map<Osoba>(userResponse);

            try
            {
                // save 
                _userServ.Create(user, userResponse.Haslo);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userServ.GetAll();
            var userResponses = _mapper.Map<IList<UserResponse>>(users);
            return Ok(userResponses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userServ.GetById(id);
            var userResponse = _mapper.Map<UserResponse>(user);
            return Ok(userResponse);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserResponse userResponse)
        {
            // map dto to entity and set id
            var user = _mapper.Map<Osoba>(userResponse);
            user.IdOsoby = id;

            try
            {
                // save 
                _userServ.Update(user, userResponse.Haslo);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userServ.Delete(id);
            return Ok();
        }

    }
}