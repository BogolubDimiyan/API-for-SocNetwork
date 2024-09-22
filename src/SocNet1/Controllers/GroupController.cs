using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SocNetq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public GroupController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Group> group = Context.Groups.ToList();
            return Ok(group);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Group? group = Context.Groups.Where(x => x.Id == id).FirstOrDefault();
            if (group == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(group);
        }

        [HttpPost]
        public IActionResult Add(Group group)
        {
            Context.Groups.Add(group);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Group group)
        {
            Context.Groups.Update(group);
            Context.SaveChanges();
            return Ok(group);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Group? group = Context.Groups.Where(x => x.Id == id).FirstOrDefault();
            Context.Groups.Remove(group);
            Context.SaveChanges();
            return Ok();
        }
    }
}
