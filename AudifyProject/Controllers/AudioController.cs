using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudifyProject.Filter;
using AudifyProject.Services;
using AudifyProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudifyProject.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly IItemService _itemService;
        public AudioController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet("topaudio/{count}")]
        public async Task<IActionResult> GetTopAudio(int count)
        {
            var items = await _itemService.GetTopAudioList(count);
            var response =new BaseResponse<List<ItemViewModel>>(items);
            response.StatusCode = 200;
            response.Result = true;
            return Ok(response);
        }
        [HttpGet("author/{authorId}")]
        public async Task<IActionResult> GetItemListByAuthor(long authorId)
        {
            var items = await _itemService.GetItemListByAuthor(authorId);
            var response = new BaseResponse<List<ItemViewModel>>(items);
            response.StatusCode = 200;
            response.Result = true;
            return Ok(response);
           
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetItemsListByCategory(long categoryId, [FromQuery]PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var result = await _itemService.GetItemListByCategory(categoryId, validFilter);
            return Ok(result);
        }
    }
}
