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
    public class NotificationController : ControllerBase
    {

        private INotificationService _notiService;
        public NotificationController(INotificationService notiService)
        {
            _notiService = notiService;
        }

        /// <summary>
        /// Создание нового оповещения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "user_id": "1"
        ///     "message": "Привет! Как дела?"
        ///     "type": "Новое сообщение"
        ///     "is_read": "0"
        ///     "created_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _notiService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _notiService.GetById(id);
            var response = result.Adapt<GetNotificationsResponse>();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateNotificationsRequest request)
        {
            var notiDto = request.Adapt<Notification>();
            await _notiService.Create(notiDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Notification notiDto)
        {
            await _notiService.Update(notiDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _notiService.Delete(id);
            return Ok();
        }
    }
}