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

        public IEnumerable<User> GetSubAlterneUsers(long id)
        {
            return GetBaseQueryable().Where(x => x.IdManagerUser == id);
        }

        public IEnumerable<User> GetColeagueUsers(long id, long managerId)
        {
            return GetBaseQueryable().Where(x => x.Id != id && x.IdManagerUser == managerId);
        }

        public IEnumerable<User> GetManagerUsers(long managerId)
        {
            return GetBaseQueryable().Where(x => x.Id == managerId);
        }
    }
}
