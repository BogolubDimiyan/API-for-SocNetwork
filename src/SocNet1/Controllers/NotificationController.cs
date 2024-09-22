using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        public SocialNetContext Context { get; }

        public NotificationController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Notification> not = Context.Notifications.ToList();
            return Ok(not);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Notification? not = Context.Notifications.Where(x => x.Id == id).FirstOrDefault();
            if (not == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(not);
        }

        [HttpPost]
        public IActionResult Add(Notification not)
        {
            Context.Notifications.Add(not);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Notification not)
        {
            Context.Notifications.Update(not);
            Context.SaveChanges();
            return Ok(not);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Notification? not = Context.Notifications.Where(x => x.Id == id).FirstOrDefault();
            Context.Notifications.Remove(not);
            Context.SaveChanges();
            return Ok();
        }
    }
}