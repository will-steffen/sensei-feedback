using Feedback.DataAccess.Entities;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback.Business.Entities
{
    public class UserBusiness : BaseBusinesss
    {
        public UserDataAccess _userDataAccess { get; set; }

        public UserBusiness(UserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public User GetById(long id)
        {
            User user = _userDataAccess.GetById(id);
            if (user == null)
            {
                throw new Exception("invalid userId");
            }
            return user;
        }

        public User Authenticate(string username, string password)
        {
            User user = _userDataAccess.GetByUsername(username);
            // No time to implement Hash, sorry;
            if(user == null || user.HashPassword != password)
            {
                throw new Exception("invalid credentials");
            }
            return user;
        }

        public List<User> GetRelatedUsers(long id)
        {
            // I know there is better ways to do that
            User user = GetById(id);
            IEnumerable<User> relatedUsers = _userDataAccess.GetSubAlterneUsers(user.Id);
            if(user.IdManagerUser != null)
            {
                relatedUsers = relatedUsers.Concat(_userDataAccess.GetColeagueUsers(user.Id, user.IdManagerUser.Value));
                relatedUsers = relatedUsers.Concat(_userDataAccess.GetManagerUsers(user.IdManagerUser.Value));
            }
            return relatedUsers.ToList();
        }
    }
}
