using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocNet1.Contracts;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventattendeeController : ControllerBase
    {
        private IEventAttendeeService _eventaService;
        public EventattendeeController(IEventAttendeeService eventaService)
        {
            _eventaService = eventaService;
        }

        /// <summary>
        /// Создание нового посетителя ивента
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "event_id": "1"
        ///     "user_id": "2"
        ///     "status": "приглашен"
        ///     "joined_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateEventAttendeeRequest request)
        {
            var evDto = request.Adapt<EventAttendee>();
            await _eventaService.Create(evDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных о участниках мероприятия
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(EventAttendee ev)
        {
            await _eventaService.Update(ev);
            return Ok();
        }

        /// <summary>
        /// Удаление данных о участниках мероприятия
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventaService.Delete(id);
            return Ok();
        }
    }
}