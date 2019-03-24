using Feedback.DataAccess.Entities;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback.Business.Entities
{
    public class FeedbackModelBusiness : BaseBusinesss
    {
        public FeedbackModelDataAccess _feedbackModelDataAccess { get; set; }

        public FeedbackModelBusiness(FeedbackModelDataAccess feedbackModelDataAccess)
        {
            _feedbackModelDataAccess = feedbackModelDataAccess;
        }

        public FeedbackModel GetById(long id)
        {
            FeedbackModel fm = _feedbackModelDataAccess.GetById(id);
            if (fm == null)
            {
                throw new Exception("invalid feedbackId");
            }
            return fm;
        }

    }
}
