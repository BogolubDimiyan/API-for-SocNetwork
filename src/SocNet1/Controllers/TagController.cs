using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using BusinessLogic.Services;
using SocNet1.Contracts;
using Mapster;
namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// Создание нового тега поста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "name": "#DogsAndCats"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tagService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _tagService.GetById(id);
            var response = result.Adapt<GetTagResponse>();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePostTagsRequest request)
        {
            var tgDto = request.Adapt<Tag>();
            await _tagService.Create(tgDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Tag tg)
        {
            await _tagService.Update(tg);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagService.Delete(id);
            return Ok();
        }
    }
}
