using Feedback.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback.DomainModel
{
    public class AppContext : DbContext
    {
        public DbSet<Competence> Competence { get; set; }
        public DbSet<Evaluate> Evaluate { get; set; }
        public DbSet<Entities.Feedback> Feedback { get; set; }
        public DbSet<FeedbackSeason> FeedbackSeason { get; set; }
        public DbSet<LinkUserProject> LinkUserProject { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }
    }
}
