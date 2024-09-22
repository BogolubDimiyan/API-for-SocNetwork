using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public FriendController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Friend> fr = Context.Friends.ToList();
            return Ok(fr);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Friend? fr = Context.Friends.Where(x => x.Id == id).FirstOrDefault();
            if (fr == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(fr);
        }

        [HttpPost]
        public IActionResult Add(Friend fr)
        {
            Context.Friends.Add(fr);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Friend fr)
        {
            Context.Friends.Update(fr);
            Context.SaveChanges();
            return Ok(fr);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Friend? fr = Context.Friends.Where(x => x.Id == id).FirstOrDefault();
            Context.Friends.Remove(fr);
            Context.SaveChanges();
            return Ok();
        }
    }
}