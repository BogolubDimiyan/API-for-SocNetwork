using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMemberController : ControllerBase
    {
        public SocialNetContext Context { get; }

        public GroupMemberController(SocialNetContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GroupMember> gm = Context.GroupMembers.ToList();
            return Ok(gm);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GroupMember? gm = Context.GroupMembers.Where(x => x.Id == id).FirstOrDefault();
            if (gm == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(gm);
        }

        [HttpPost]
        public IActionResult Add(GroupMember gm)
        {
            Context.GroupMembers.Add(gm);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(GroupMember gm)
        {
            Context.GroupMembers.Update(gm);
            Context.SaveChanges();
            return Ok(gm);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            GroupMember? gm = Context.GroupMembers.Where(x => x.Id == id).FirstOrDefault();
            Context.GroupMembers.Remove(gm);
            Context.SaveChanges();
            return Ok();
        }
    }
}
