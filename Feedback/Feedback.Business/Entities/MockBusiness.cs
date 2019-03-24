using Feedback.DataAccess.Entities;
using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback.Business.Entities
{
    public class MockBusiness
    {
        public UserDataAccess _userDataAccess { get; set; }

        public MockBusiness(UserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public void Mock()
        {
            MockUsers();
        }

        private void MockUsers()
        {
            User manager = new User
            {
                Name = "Manager",
                Role = Role.Manager,
                Username = "manager",
                HashPassword = "manager",
                Email = "manager@sensei-feedback.com"
            };
            _userDataAccess.Save(manager);

            List<User> engineers = new List<User>
            {
                new User
                {
                    Name = "Main User",
                    Username = "user",
                    Email = "user@sensei-fedback.com",
                    HashPassword = "user",
                    Role = Role.Engineer,
                    ManagerUser = manager
                },
                new User
                {
                    Name = "Coleague User",
                    Username = "coleague",
                    Email = "coleague@sensei-fedback.com",
                    HashPassword = "coleague",
                    Role = Role.Engineer,
                    ManagerUser = manager
                },
            };
            _userDataAccess.Save(engineers);


            User intern = new User
            {
                Name = "Intern",
                Role = Role.Intern,
                Username = "intern",
                HashPassword = "intern",
                Email = "intern@sensei-feedback.com",
                ManagerUser = engineers[0]
            };
            _userDataAccess.Save(intern);
        }
    }
}
