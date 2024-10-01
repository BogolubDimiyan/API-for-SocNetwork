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
    public class FriendController : ControllerBase
    {
        private IFriendService _friendService;
        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        /// <summary>
        /// Создание нового друга
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "requester_id": "3"
        ///     "receiver_id": "1"
        ///     "status": "Друзья"
        ///     "created_at": "2023-10-05 14:30:45.123456"
        ///     "updated_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateFriendsRequest request)
        {
            var GmDto = request.Adapt<Friend>();
            await _friendService.Create(GmDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных о друзьях
        /// </summary>
        /// <param name="friendss"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Friend friendss)
        {
            await _friendService.Update(friendss);
            return Ok();
        }

        /// <summary>
        /// Удаление данных о друзьях1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _friendService.Delete(id);
            return Ok();
        }
    }
}