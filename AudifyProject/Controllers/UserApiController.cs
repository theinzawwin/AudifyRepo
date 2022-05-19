using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudifyProject.Services;
using AudifyProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AudifyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            bool result = false;
            try
            {
                result=await _userService.Register(registerVM);
            }catch(Exception e)
            {
                result = false;
            }

            return Ok(true);
        }

        // GET api/<UserApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
