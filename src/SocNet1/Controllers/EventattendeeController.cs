using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventattendeeController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public EventattendeeController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<EventAttendee> eas = Context.EventAttendees.ToList();
            return Ok(eas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EventAttendee? eas = Context.EventAttendees.Where(x => x.Id == id).FirstOrDefault();
            if (eas == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(eas);
        }

        [HttpPost]
        public IActionResult Add(EventAttendee eas)
        {
            Context.EventAttendees.Add(eas);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EventAttendee eas)
        {
            Context.EventAttendees.Update(eas);
            Context.SaveChanges();
            return Ok(eas);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            EventAttendee? eas = Context.EventAttendees.Where(x => x.Id == id).FirstOrDefault();
            Context.EventAttendees.Remove(eas);
            Context.SaveChanges();
            return Ok();
        }
    }
}