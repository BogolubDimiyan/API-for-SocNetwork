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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Message> mes = Context.Messages.ToList();
            return Ok(mes);
        }

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

        [HttpPost]
        public IActionResult Add(Message mes)
        {
            Context.Messages.Add(mes);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Message mes)
        {
            Context.Messages.Update(mes);
            Context.SaveChanges();
            return Ok(mes);
        }

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
