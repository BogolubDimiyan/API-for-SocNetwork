using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public BlockController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<BlockedUser> block = Context.BlockedUsers.ToList();
            return Ok(block);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BlockedUser? block = Context.BlockedUsers.Where(x => x.Id == id).FirstOrDefault();
            if (block == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(block);
        }

        [HttpPost]
        public IActionResult Add(BlockedUser block)
        {
            Context.BlockedUsers.Add(block);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(BlockedUser block)
        {
            Context.BlockedUsers.Update(block);
            Context.SaveChanges();
            return Ok(block);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BlockedUser? block = Context.BlockedUsers.Where(x => x.Id == id).FirstOrDefault();
            Context.BlockedUsers.Remove(block);
            Context.SaveChanges();
            return Ok(block);
        }
    }
}