using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MassegeController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public MassegeController(SocialNetContext context)
        {
            Context = context;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Message> mes = Context.Messages.ToList();
            return Ok(mes);
        }

        /// <summary>
        /// Получение id собщения
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Message? mes = Context.Messages.Where(x => x.Id == id).FirstOrDefault();
            if (mes == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(mes);
        }

        /// <summary>
        /// Добавление данных о сообщениях
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Message mes)
        {
            Context.Messages.Add(mes);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Обновление данных о сообщениях
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Message mes)
        {
            Context.Messages.Update(mes);
            Context.SaveChanges();
            return Ok(mes);
        }

        /// <summary>
        /// удаление данных о сообщении
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Message? mes = Context.Messages.Where(x => x.Id == id).FirstOrDefault();
            Context.Messages.Remove(mes);
            Context.SaveChanges();
            return Ok();
        }
    }
}
