using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocNet1.Contracts;

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

        /// <summary>
        /// Получение id лайков
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _likeService.GetById(id);
            var response = result.Adapt<GetLikesResponse>();
            return Ok(response);
        }


        /// <summary>
        /// Добавление данных лайков
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateLikesRequest request)
        {
            var likeDto = request.Adapt<Like>();
            await _likeService.Create(likeDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных о лайках
        /// </summary>
        /// <param name="likeDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Like likeDto)
        {
            await _likeService.Update(likeDto);
            return Ok();
        }

        /// <summary>
        /// Удаление данных о лайках
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _likeService.Delete(id);
            return Ok();
        }
    }
}