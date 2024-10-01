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

        /// <summary>
        /// получение id оповещения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _notiService.GetById(id);
            var response = result.Adapt<GetNotificationsResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Добавление данных об оповещениях
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateNotificationsRequest request)
        {
            var notiDto = request.Adapt<Notification>();
            await _notiService.Create(notiDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных об оповещених
        /// </summary>
        /// <param name="notiDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Notification notiDto)
        {
            await _notiService.Update(notiDto);
            return Ok();
        }

        /// <summary>
        /// Удаление данных об оповещении
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _notiService.Delete(id);
            return Ok();
        }
    }
}