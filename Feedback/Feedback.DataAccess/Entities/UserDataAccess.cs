using Feedback.DomainModel;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback.DataAccess.Entities
{
    public class UserDataAccess : BaseDataAccess<User>
    {
        public UserDataAccess(ApplicationContext ctx) : base(ctx) { }

        public User GetByUsername(string username)
        {
            return GetBaseQueryable().Where(x => x.Username == username).FirstOrDefault();
        }
    }
}
