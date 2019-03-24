using Feedback.DataAccess.Entities;
using Feedback.DomainModel;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback.Business.Entities
{
    public class FeedbackSeasonBusiness : BaseBusinesss
    {
        public FeedbackSeasonDataAccess _feedbackSeasonDataAccess { get; set; }

        public FeedbackSeasonBusiness(FeedbackSeasonDataAccess feedbackSeasonDataAccess)
        {
            _feedbackSeasonDataAccess = feedbackSeasonDataAccess;
        }

        public FeedbackSeason GetCurrent()
        {
            FeedbackSeason fs = _feedbackSeasonDataAccess.GetByDate(DateUtils.Now());
            if (fs == null)
            {
                throw new Exception("No Season been made");
            }
            return fs;
        }

        public IEnumerable<FeedbackSeason> List()
        {
            return _feedbackSeasonDataAccess.List();
        }
    }
}
