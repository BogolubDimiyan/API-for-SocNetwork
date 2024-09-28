using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using SocNet1.Contracts;
using Mapster;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private ILikeService _likeService;
        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        /// <summary>
        /// Создание нового понравившегося поста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "post_id": "23"
        ///     "user_id": "1"
        ///     "created_at": "2023-10-05 14:30:45.123456"
        ///     }
        ///     
        /// </remarks>
        /// <returns></returns>


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _likeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _likeService.GetById(id);
            var response = result.Adapt<GetLikesResponse>();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateLikesRequest request)
        {
            var likeDto = request.Adapt<Like>();
            await _likeService.Create(likeDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Like likeDto)
        {
            await _likeService.Update(likeDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _likeService.Delete(id);
            return Ok();
        }
    }
}
