using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocNet1.Contracts;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Создание нового ивента
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     name": "Вечеринка в честь дня рождения",
        ///     "description": "Приглашаем всех на вечеринку в честь дня рождения!",
        ///     "location": "Москва, ул. Ленина, д. 10",
        ///     "start_time": "2023-10-15T18:00:00",
        ///     "end_time": "2023-10-15T23:00:00",
        ///     "created_by": "5",
        ///     "created_at": "2023-10-05T14:30:45.123456",
        ///     "updated_at": "2023-10-05T14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateEventsRequest request)
        {
            var evDto = request.Adapt<Event>();
            await _eventService.Create(evDto);
            return Ok();
        }

        /// <summary>
        /// обновление данных о событиях
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Event ev)
        {
            await _eventService.Update(ev);
            return Ok();
        }

        /// <summary>
        /// Удаление данных о событии
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.Delete(id);
            return Ok();
        }
    }
}