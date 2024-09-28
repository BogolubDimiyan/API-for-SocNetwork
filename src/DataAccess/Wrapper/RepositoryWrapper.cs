using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SocialNetContext _repoContext;

        private IUserRepository _user;
        private ITagRepository _tag;
        private IPrivacySettingRepository _priv;
        private IPostTagRepository _posttg;
        private IPostRepository _post;
        private INotificationRepository _noti;
        private IMessageRepository _message;
        private ILikeRepository _like;
        private IGroupMemberRepository _gm;
        private IGroupRepository _gdull;
        private IFriendRepository _friend;
        private IEventAttendeeRepository _ea;
        private IEventRepository _ev;
        private ICommentRepository _com;
        private IBlockedUserRepository _bu;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
               
        }

        public ITagRepository Tag
        {
            get
            {
                if (_tag == null)
                {
                    _tag = new TagRepository(_repoContext);
                }
                return _tag;
            }
        }

        public IPrivacySettingRepository Priv
        {
            get
            {
                if (_priv == null)
                {
                    _priv = new PrivacySettingRepository(_repoContext);
                }
                return _priv;
            }
        }

        public IPostTagRepository PostTg
        {
            get
            {
                if (_posttg == null)
                {
                    _posttg = new PostTagRepository(_repoContext);
                }
                return _posttg;
            }
        }

        public IPostRepository Post
        {
            get
            {
                if (_post == null)
                {
                    _post = new PostRepository(_repoContext);
                }
                return _post;
            }
        }

        public INotificationRepository Noti
        {
            get
            {
                if (_noti == null)
                {
                    _noti = new NotificationRepository(_repoContext);
                }
                return _noti;
            }
        }

        public IMessageRepository Message
        {
            get
            {
                if (_message == null)
                {
                    _message = new MessageRepository(_repoContext);
                }
                return _message;
            }
        }

        public ILikeRepository Like
        {
            get
            {
                if (_like == null)
                {
                    _like = new LikeRepository(_repoContext);
                }
                return _like;
            }

        }

        public IGroupMemberRepository Gm
        {
            get
            {
                if (_gm == null)
                {
                    _gm = new GroupMemberRepository(_repoContext);
                }
                return _gm;
            }

        }

        public IGroupRepository G
        {
            get
            {
                if (_gdull == null)
                {
                    _gdull = new GroupRepository(_repoContext);
                }
                return _gdull;
            }

        }

        public IFriendRepository Friend
        {
            get
            {
                if (_friend == null)
                {
                    _friend = new FriendRepository(_repoContext);
                }
                return _friend;
            }

        }

        public IEventAttendeeRepository Ea
        {
            get
            {
                if (_ea == null)
                {
                    _ea = new EventAttendeeRepository(_repoContext);
                }
                return _ea;
            }

        }

        public IEventRepository Ev
        {
            get
            {
                if (_ev == null)
                {
                    _ev = new EventRepository(_repoContext);
                }
                return _ev;
            }

        }

        public ICommentRepository Com
        {
            get
            {
                if (_com == null)
                {
                    _com = new CommentRepository(_repoContext);
                }
                return _com;
            }

        }

        public IBlockedUserRepository Bu
        {
            get
            {
                if (_bu == null)
                {
                    _bu = new BlockedUserRepository(_repoContext);
                }
                return _bu;
            }

        }


        public RepositoryWrapper(SocialNetContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        {
           await _repoContext.SaveChangesAsync();
        }
    }

    
}
