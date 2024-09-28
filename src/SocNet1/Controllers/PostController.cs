using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using SocNet1.Contracts;
using Mapster;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;
        public PostController(IPostService posService)
        {
            _postService = posService;
        }

        /// <summary>
        /// Создание нового поста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "user_id": "1"
        ///     "[content]": "В данном посте мы разберемся кто такой архитектор ПО и из чего состоит его работа..."
        ///     "image_url": "ссылка на фото внутри файловой системы"
        ///     "created_at": "2023-10-05 14:30:45.123456"
        ///     "Updated_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _postService.GetById(id);
            var response = result.Adapt<GetPostsResponse>();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePostTagsRequest request)
        {
            var tgDto = request.Adapt<Post>();
            await _postService.Create(tgDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Post pos)
        {
            await _postService.Update(pos);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.Delete(id);
            return Ok();
        }
    }
}
