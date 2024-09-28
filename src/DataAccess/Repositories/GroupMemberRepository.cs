using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GroupMemberRepository : RepositoryBase<GroupMember>, IGroupMemberRepository
    {
        public GroupMemberRepository(SocialNetContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
