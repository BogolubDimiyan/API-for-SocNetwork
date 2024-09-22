using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public LikeController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Like> like = Context.Likes.ToList();
            return Ok(like);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Like? like = Context.Likes.Where(x => x.Id == id).FirstOrDefault();
            if (like == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(like);
        }

        [HttpPost]
        public IActionResult Add(Like like)
        {
            Context.Likes.Add(like);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Like like)
        {
            Context.Likes.Update(like);
            Context.SaveChanges();
            return Ok(like);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Like? like = Context.Likes.Where(x => x.Id == id).FirstOrDefault();
            Context.Likes.Remove(like);
            Context.SaveChanges();
            return Ok();
        }
    }
}
