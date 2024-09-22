using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagPostController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public TagPostController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<PostTag> ptag = Context.PostTags.ToList();
            return Ok(ptag);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PostTag? ptag = Context.PostTags.Where(x => x.Id == id).FirstOrDefault();
            if (ptag == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(ptag);
        }

        [HttpPost]
        public IActionResult Add(PostTag ptag)
        {
            Context.PostTags.Add(ptag);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(PostTag ptag)
        {
            Context.PostTags.Update(ptag);
            Context.SaveChanges();
            return Ok(ptag);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            PostTag? ptag = Context.PostTags.Where(x => x.Id == id).FirstOrDefault();
            Context.PostTags.Remove(ptag);
            Context.SaveChanges();
            return Ok();
        }
    }
}
