using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Domain.Models;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public PostController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Post> post = Context.Posts.ToList();
            return Ok(post);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Post? post = Context.Posts.Where(x => x.Id == id).FirstOrDefault();
            if (post == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Add(Post post)
        {
            Context.Posts.Add(post);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Post post)
        {
            Context.Posts.Update(post);
            Context.SaveChanges();
            return Ok(post);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Post? post = Context.Posts.Where(x => x.Id == id).FirstOrDefault();
            Context.Posts.Remove(post);
            Context.SaveChanges();
            return Ok();
        }
    }
}
