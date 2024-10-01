using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocNet1.Contracts;
using System.Xml.Linq;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _comService;
        public CommentController(ICommentService comService)
        {
            _comService = comService;
        }


        /// <summary>
        /// Создание нового комментария
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "post_id": "34"
        ///     "user_id": "1"
        ///     "content": "Даа, согласен, звучит потрясающе!!!"
        ///     "created_at": "2023-10-05 14:30:45.123456"
        ///     "updated_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentsRequest request)
        {
            var evDto = request.Adapt<Comment>();
            await _comService.Create(evDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных о комментарии
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Comment com)
        {
            await _comService.Update(com);
            return Ok();
        }

        /// <summary>
        /// Удаление данных о комментариях
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _comService.Delete(id);
            return Ok();
        }
    }
}