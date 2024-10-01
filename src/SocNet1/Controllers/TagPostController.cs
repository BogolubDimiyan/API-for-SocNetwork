using BusinessLogic.Services;
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
    public class TagPostController : ControllerBase
    {
        private IPostTagService _posttgService;
        public TagPostController(IPostTagService posttgService)
        {
            _posttgService = posttgService;
        }

        /// <summary>
        /// Полученние всех данных о тегах постов
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _posttgService.GetAll());
        }

        /// <summary>
        /// получение id тега
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _posttgService.GetById(id);
            var response = result.Adapt<GetPostTagsResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового тега у поста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "post_id": "1"
        ///     "tag_id": "1"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreatePostTagsRequest request)
        {
            var postgDto = request.Adapt<PostTag>();
            await _posttgService.Create(postgDto);
            return Ok();
        }

        /// <summary>
        /// обновление данных о тегах постов
        /// </summary>
        /// <param name="posttg"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(PostTag posttg)
        {
            await _posttgService.Update(posttg);
            return Ok();
        }

        /// <summary>
        /// удаление данных о тегах постов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _posttgService.Delete(id);
            return Ok();
        }
    }
}