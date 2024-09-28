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

        [HttpPut]
        public async Task<IActionResult> Update(BlockedUser bl)
        {
            await _blService.Update(bl);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _blService.Delete(id);
            return Ok();
        }
    }
}