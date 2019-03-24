using Feedback.DataAccess.Entities;
using Feedback.DomainModel;
using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback.Business.Entities
{
    public class MockBusiness
    {
        public UserDataAccess _userDataAccess { get; set; }
        public FeedbackSeasonDataAccess _feedbackSeasonDataAccess { get; set; }
        public ProjectDataAccess _projectDataAccess { get; set; }
        public CompetenceDataAccess _competenceDataAccess { get; set; }

        public MockBusiness(
            UserDataAccess userDataAccess, 
            FeedbackSeasonDataAccess feedbackSeasonDataAccess,
            ProjectDataAccess projectDataAccess,
            CompetenceDataAccess competenceDataAccess
        ) {
            _userDataAccess = userDataAccess;
            _feedbackSeasonDataAccess = feedbackSeasonDataAccess;
            _projectDataAccess = projectDataAccess;
            _competenceDataAccess = competenceDataAccess;
        }

        public void Mock()
        {
            MockUsers();
            MockSeasons();
            MockProject();
            MockCompetences();
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

        private void MockSeasons()
        {
            DateTime date = DateUtils.Now().AddDays(-1);
            FeedbackSeason season = new FeedbackSeason
            {
                StartDate = date,
                EndDate = date.AddDays(5)
            };
            _feedbackSeasonDataAccess.Save(season);

            FeedbackSeason season2 = new FeedbackSeason
            {
                StartDate = date.AddDays(5),
                EndDate = date.AddDays(15)
            };
            _feedbackSeasonDataAccess.Save(season2);

            FeedbackSeason season3 = new FeedbackSeason
            {
                StartDate = date.AddDays(15),
                EndDate = date.AddDays(30)
            };
            _feedbackSeasonDataAccess.Save(season3);

            FeedbackSeason season4 = new FeedbackSeason
            {
                StartDate = date.AddDays(30),
                EndDate = date.AddDays(60)
            };
            _feedbackSeasonDataAccess.Save(season3);
        }

        private void MockProject()
        {
            Project project = new Project { Name = "Awesome Project" };
            _projectDataAccess.Save(project);

            List<User> userList = _userDataAccess.List().ToList();
            userList.ForEach(x => {
                x.ProjectList = new List<LinkUserProject>
                {
                    new LinkUserProject { Project = project }
                };
            });
            _userDataAccess.Save(userList);
        }

        private void MockCompetences()
        {
            List<Competence> competenceList = new List<Competence>
            {
                new Competence
                {
                    Name = "Communication",
                    Description = "Is this person a good Communicator?"
                },
                new Competence
                {
                    Name = "Leader",
                    Description = "Is this person a good Leader?",
                    Role = Role.Manager
                },
                new Competence
                {
                    Name = "Team Work",
                    Description = "Is this a good person to work with?",
                    Role = Role.Intern
                },
            };
            _competenceDataAccess.Save(competenceList);
        }
    }
}
