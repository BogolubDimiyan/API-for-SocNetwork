using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using SocNet1.Contracts;
using Domain.Interfaces;
using BusinessLogic.Services;
using Mapster;

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


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _posttgService.GetAll());
        }

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

        [HttpPut]
        public async Task<IActionResult> Update(PostTag posttg)
        {
            await _posttgService.Update(posttg);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _posttgService.Delete(id);
            return Ok();
        }
    }
}
