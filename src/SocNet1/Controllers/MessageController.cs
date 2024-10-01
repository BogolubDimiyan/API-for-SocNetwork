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
    public class MassegeController : ControllerBase
    {
        private IMessageService _messageService;
        public MassegeController(IMessageService friendService)
        {
            _messageService = friendService;
        }

        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "sender_id": "1"
        ///     "receiver_id": "2"
        ///     "content": "Привеет! Куда пропал?"
        ///     "read_status": "1"
        ///     "created_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateMessageRequest request)
        {
            var GmDto = request.Adapt<Message>();
            await _messageService.Create(GmDto);
            return Ok();
        }

        /// <summary>
        /// Получение id собщения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _messageService.GetById(id);
            var response = result.Adapt<GetMessageResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Обновление данных о сообщениях
        /// </summary>
        /// <param name="Gm"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Message Gm)
        {
            await _messageService.Update(Gm);
            return Ok();
        }

        /// <summary>
        /// удаление данных о сообщении
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _messageService.Delete(id);
            return Ok();
        }
    }
}