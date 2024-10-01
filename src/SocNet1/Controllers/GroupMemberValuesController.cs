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
    public class GroupMemberController : ControllerBase
    {
        private IGroupMemberService _GmService;
        public GroupMemberController(IGroupMemberService GmService)
        {
            _GmService = GmService;
        }

        /// <summary>
        /// Создание нового участника группы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "group_id": "90"
        ///     "user_id": "2"
        ///     "role": "администратор"
        ///     "joined_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateGroupMembersRequest request)
        {
            var GmDto = request.Adapt<GroupMember>();
            await _GmService.Create(GmDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных об участниках группы
        /// </summary>
        /// <param name="Gm"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GroupMember Gm)
        {
            await _GmService.Update(Gm);
            return Ok();
        }

        /// <summary>
        /// Удаление данных об участниках группы
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _GmService.Delete(id);
            return Ok();
        }
    }
}