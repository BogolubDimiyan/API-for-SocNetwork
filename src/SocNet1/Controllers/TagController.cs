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
    public class TagController : ControllerBase
    {
        private ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// получение данных о всех тегах
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tagService.GetAll());
        }

        /// <summary>
        /// получение if тега
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _tagService.GetById(id);
            var response = result.Adapt<GetTagResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового тега 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "name": "#DogsAndCats"
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreatePostTagsRequest request)
        {
            var tgDto = request.Adapt<Tag>();
            await _tagService.Create(tgDto);
            return Ok();
        }

        /// <summary>
        /// обновление данных о тегах
        /// </summary>
        /// <param name="tg"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Tag tg)
        {
            await _tagService.Update(tg);
            return Ok();
        }

        /// <summary>
        /// Удаление данных о тегах
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagService.Delete(id);
            return Ok();
        }
    }
}