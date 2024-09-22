using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using System.Xml.Linq;

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public CommentController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Comment> com = Context.Comments.ToList();
            return Ok(com);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Comment? com = Context.Comments.Where(x => x.Id == id).FirstOrDefault();
            if (com == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(com);
        }

        [HttpPost]
        public IActionResult Add(Comment com)
        {
            Context.Comments.Add(com);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Comment com)
        {
            Context.Comments.Update(com);
            Context.SaveChanges();
            return Ok(com);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Comment? com = Context.Comments.Where(x => x.Id == id).FirstOrDefault();
            Context.Comments.Remove(com);
            Context.SaveChanges();
            return Ok();
        }
    }
}