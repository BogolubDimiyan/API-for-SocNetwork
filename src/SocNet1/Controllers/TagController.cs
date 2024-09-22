using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public TagController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Tag> tag = Context.Tags.ToList();
            return Ok(tag);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Tag? tag = Context.Tags.Where(x => x.Id == id).FirstOrDefault();
            if (tag == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(tag);
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            Context.Tags.Add(tag);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Tag tag)
        {
            Context.Tags.Update(tag);
            Context.SaveChanges();
            return Ok(tag);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Tag? tag = Context.Tags.Where(x => x.Id == id).FirstOrDefault();
            Context.Tags.Remove(tag);
            Context.SaveChanges();
            return Ok();
        }
    }
}
