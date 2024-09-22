using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Models;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public EventController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Event> events = Context.Events.ToList();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Event? events = Context.Events.Where(x => x.Id == id).FirstOrDefault();
            if (events == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(events);
        }

        [HttpPost]
        public IActionResult Add(Event events)
        {
            Context.Events.Add(events);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Event events)
        {
            Context.Events.Update(events);
            Context.SaveChanges();
            return Ok(events);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Event? events = Context.Events.Where(x => x.Id == id).FirstOrDefault();
            Context.Events.Remove(events);
            Context.SaveChanges();
            return Ok();
        }
    }
}
