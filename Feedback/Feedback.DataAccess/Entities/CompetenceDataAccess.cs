using Feedback.DomainModel;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback.DataAccess.Entities
{
    public class CompetenceDataAccess : BaseDataAccess<Competence>
    {
        public CompetenceDataAccess(ApplicationContext ctx) : base(ctx) { }       
    }
}
