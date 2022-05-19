using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudifyProject.Services;
using AudifyProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AudifyProject.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorApiController : ControllerBase
    {

        private readonly IAuthorService _authorService;
        public AuthorApiController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET: api/<AuthorApiController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors =await _authorService.GetAuthorList();
            var response = new BaseResponse<List<AuthorViewModel>>(authors);
            response.StatusCode = 200;
            response.Result = true;
            return Ok(response);
        }
        [HttpGet("topAuthors")]
        public async Task<IActionResult> GetTop5Authors()
        {
            var authors = await _authorService.GetTop5List();
            var response = new BaseResponse<List<AuthorViewModel>>(authors);
            response.StatusCode = 200;
            response.Result = true;
            return Ok(response);
        }

        // GET api/<AuthorApiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_authorService.GetAuthorWithItems(id));
        }

        // POST api/<AuthorApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        
    }
}
