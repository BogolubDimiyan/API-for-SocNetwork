using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SocNet1.Contracts;

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
        /// получение всех данных о постах
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetAll());
        }

        /// <summary>
        /// получени id поста
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _postService.GetById(id);
            var response = result.Adapt<GetPostsResponse>();
            return Ok(response);
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
        [HttpPost]
        public async Task<IActionResult> Add(CreatePostTagsRequest request)
        {
            var tgDto = request.Adapt<Post>();
            await _postService.Create(tgDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных постов
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Post pos)
        {
            await _postService.Update(pos);
            return Ok();
        }

        /// <summary>
        /// Удаление данных постов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.Delete(id);
            return Ok();
        }
    }
}