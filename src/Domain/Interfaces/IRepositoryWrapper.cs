using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User {  get; }
        ITagRepository Tag { get; }
        IPrivacySettingRepository Priv {  get; }
        IPostTagRepository PostTg { get; }
        IPostRepository Post { get; }
        INotificationRepository Noti { get; }
        IMessageRepository Message {  get; }
        ILikeRepository Like { get; }
        IGroupMemberRepository Gm { get; }
        IGroupRepository G { get; }
        IFriendRepository Friend { get; }
        IEventAttendeeRepository Ea { get; }
        IEventRepository Ev { get; }
        ICommentRepository Com { get; }
        IBlockedUserRepository Bu {  get; }
        Task Save();
    }

}
