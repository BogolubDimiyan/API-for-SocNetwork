﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;
using SocNet1.Contracts;
using Mapster;

namespace SocNetq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupService _GService;
        public GroupController(IGroupService GService)
        {
            _GService = GService;
        }

        /// <summary>
        /// Создание новой группы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "name": "Coockies"
        ///     "description": "Группа, созданная программистами для программистов"
        ///     "created_by": "1"
        ///     "created_at": "2023-10-05 14:30:45.123456"
        ///     "updated_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateGroupRequest request)
        {
            var GmDto = request.Adapt<Group>();
            await _GService.Create(GmDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Group G)
        {
            await _GService.Update(G);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _GService.Delete(id);
            return Ok();
        }
    }
}
