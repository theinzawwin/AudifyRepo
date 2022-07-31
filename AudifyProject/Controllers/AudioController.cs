using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AudifyProject.Filter;
using AudifyProject.Services;
using AudifyProject.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        private readonly IAuthorService _authorService;
        private readonly IReadHistoryService _readHistoryService;
        public AudioController(IItemService itemService, IAuthorService authorService, IReadHistoryService readHistoryService)
        {
            _itemService = itemService;
            _authorService = authorService;
            _readHistoryService = readHistoryService;
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
        [HttpGet("detail/{id}")]
        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetItemDetail(long id)
        {
            string userId = User.FindFirst(JwtRegisteredClaimNames.Jti).Value;
            var result = await _itemService.GetItemById(id, userId);
            var response = new BaseResponse<ItemViewModel>(result);
            return Ok(response);
        }


        [Authorize]
        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("author/follow/{id}")]
        public async Task<IActionResult> FollowAuthor(long id)
        {
            try
            {
                string userId = User.FindFirst(JwtRegisteredClaimNames.Jti).Value;
                bool result = await _authorService.FollowAuthor(id, userId);
                var response = new BaseResponse<Boolean>(result);
                return Ok(response);
            }
            catch(Exception e)
            {
                var response = new BaseResponse<Boolean>(false);
                response.ErrorMessage = e.Message;
                response.Result = false;
                return Ok(response);
            }
            
          
        }

        [Authorize]
        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("author/followList")]
        public async Task<IActionResult> FollowAuthorList()
        {
            try
            {
                string userId = User.FindFirst(JwtRegisteredClaimNames.Jti).Value;
                var followAuthorList = await _authorService.GetFollowAuthorList(userId);
                var response = new BaseResponse<List<AuthorFollowViewModel>>(followAuthorList);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new BaseResponse<String>(null);
                response.ErrorMessage = e.Message;
                response.Result = false;
                return Ok(response);
            }


        }
        [Authorize]
        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("item/favorite/{id}")]
        public async Task<IActionResult> FavoriteItem(long id)
        {
            try
            {
                string userId = User.FindFirst(JwtRegisteredClaimNames.Jti).Value;
                bool result = await _itemService.FavoriteAudio(id, userId);
                var response = new BaseResponse<Boolean>(result);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new BaseResponse<Boolean>(false);
                response.ErrorMessage = e.Message;
                response.Result = false;
                return Ok(response);
            }
        }
        [Authorize]
        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("item/favoriteList")]
        public async Task<IActionResult> FavoriteItemList()
        {
            try
            {
                string userId = User.FindFirst(JwtRegisteredClaimNames.Jti).Value;
                var favoriteItemList = await _itemService.GetFavoriteItemList(userId);
                var response = new BaseResponse<List<FavoriteItemViewModel>>(favoriteItemList);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new BaseResponse<String>(null);
                response.ErrorMessage = e.Message;
                response.Result = false;
                return Ok(response);
            }


        }
        [HttpGet("topTrendingItems")]
        public async Task<IActionResult> TopTrendItemList()
        {
            try
            {
               // string userId = User.FindFirst(JwtRegisteredClaimNames.Jti).Value;
                var favoriteItemList = await _itemService.GetTopTrending();
                var response = new BaseResponse<List<ItemViewModel>>(favoriteItemList);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new BaseResponse<String>(null);
                response.ErrorMessage = e.Message;
                response.Result = false;
                return Ok(response);
            }
        }
        [Authorize]
        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("saveListenHistory/{chapterId}")]
        public async Task<IActionResult> SaveListenHistory(Guid chapterId)
        {
            try
            {
                string userId = User.FindFirst(JwtRegisteredClaimNames.Jti).Value;
                bool result = await _readHistoryService.SaveReadHistory( userId, chapterId);
                var response = new BaseResponse<Boolean>(result);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new BaseResponse<Boolean>(false);
                response.ErrorMessage = e.Message;
                response.Result = false;
                return Ok(response);
            }
        }

        [Authorize]
        [Authorize(Roles = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("readHistoryList")]
        public async Task<IActionResult> GetReadHistoryList()
        {
            try
            {
                 string userId = User.FindFirst(JwtRegisteredClaimNames.Jti).Value;
                var favoriteItemList = await _readHistoryService.GetReadHistoryList(userId);
                var response = new BaseResponse<List<ReadHistoryViewModel>>(favoriteItemList);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new BaseResponse<String>(null);
                response.ErrorMessage = e.Message;
                response.Result = false;
                return Ok(response);
            }
        }

        [HttpGet("newReleaseList")]
        public async Task<IActionResult> GetNewReleaseList()
        {
            var items = await _itemService.GetNewReleaseList();
            var response = new BaseResponse<List<ItemViewModel>>(items);
            response.StatusCode = 200;
            response.Result = true;
            return Ok(response);
        }
        [HttpGet("search_audio")]
        public async Task<IActionResult> SearchAudio([FromQuery]string name)
        {
            var items = await _itemService.SearchAudio(name);
            var response = new BaseResponse<SearchItemViewModel>(items);
            response.StatusCode = 200;
            response.Result = true;
            return Ok(response);
        }
        [HttpPost("save_feedback")]
        public async Task<IActionResult> SaveFeedback(FeedbackViewModel feedback)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var result =await _itemService.SaveFeedback(feedback);
                response.Data=result;
            }catch(Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Result = false;
                response.StatusCode = 400;
            }
            return Ok(response);
        }

    }
}
