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
    public class BlockController : ControllerBase
    {
        private IBlockedUserService _blService;
        public BlockController(IBlockedUserService blService)
        {
            _blService = blService;
        }


        /// <summary>
        /// Создание нового заблокированного пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "blocker_id": "1"
        ///     "blocked_id": "15"
        ///     "created_at": "2023-10-05 14:30:45.123456"
        ///     "updated_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlocksRequest request)
        {
            var blDto = request.Adapt<BlockedUser>();
            await _blService.Create(blDto);
            return Ok();
        }


        /// <summary>
        /// Обноалвение данных о заблокированных пользователях
        /// </summary>
        /// <param name="bl"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(BlockedUser bl)
        {
            await _blService.Update(bl);
            return Ok();
        }

        /// <summary>
        /// Удаление заблокированных пользователей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _blService.Delete(id);
            return Ok();
        }
    }
}