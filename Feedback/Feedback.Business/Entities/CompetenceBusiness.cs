using Feedback.DataAccess.Entities;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback.Business.Entities
{
    public class CompetenceBusiness : BaseBusinesss
    {
        public CompetenceDataAccess _competenceDataAccess { get; set; }

        public CompetenceBusiness(CompetenceDataAccess competenceDataAccess)
        {
            _competenceDataAccess = competenceDataAccess;
        }

        public IEnumerable<Competence> List()
        {
            return _competenceDataAccess.List();
        }
    }
}
