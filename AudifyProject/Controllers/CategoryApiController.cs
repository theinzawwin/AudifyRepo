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
    public class CategoryApiController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        public CategoryApiController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoryApiController>
        [HttpGet("allcategory")]
        public async Task<IActionResult> Get()
        {
            var response = new BaseResponse<List<CategoryViewModel>>(await _categoryService.GetAllCategory());
            response.StatusCode = 200;
            return Ok(response);
        }
        [HttpGet("category_title_list")]
        public async Task<IActionResult> GetCategoryWithTop5Items()
        {
            var response = new BaseResponse<List<CategoryViewModel>>(await _categoryService.GetCategoryListWithTop5Items());
            response.StatusCode = 200;
            response.Result = true;
            return Ok(response);
            
        }

        // GET api/<CategoryApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
