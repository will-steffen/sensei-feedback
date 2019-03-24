using Feedback.DataAccess.Entities;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
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
    }
}
