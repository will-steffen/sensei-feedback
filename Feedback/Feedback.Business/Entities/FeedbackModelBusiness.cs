using Feedback.DataAccess.Entities;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback.Business.Entities
{
    public class FeedbackModelBusiness : BaseBusinesss
    {
        public FeedbackModelDataAccess _feedbackModelDataAccess { get; set; }
        public UserBusiness _userBusiness { get; set; }

        public FeedbackModelBusiness(
            FeedbackModelDataAccess feedbackModelDataAccess,
            UserBusiness userBusiness
        ) {
            _feedbackModelDataAccess = feedbackModelDataAccess;
            _userBusiness = userBusiness;
        }

        public IEnumerable<FeedbackModel> List()
        {
            return _feedbackModelDataAccess.List();
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

        public List<Tuple<User, FeedbackModel>> GetUsersToFeedback(long userId)
        {
            List<User> relatedUsers = _userBusiness.GetRelatedUsers(userId);
            List<Tuple<User, FeedbackModel>> feedbacks = new List<Tuple<User, FeedbackModel>>();

            relatedUsers.ForEach(x =>
            {
                FeedbackModel feedback = _feedbackModelDataAccess.GetByUsersIds(userId, x.Id);
                feedbacks.Add(new Tuple<User, FeedbackModel>(x, feedback));
            });
            return feedbacks;
        }

        public FeedbackModel IncludeFeedback(long authorId, long targetId, string comment, List<Evaluate> evaluateList)
        {
            FeedbackModel feedback = new FeedbackModel
            {
                Comment = comment,
                IdAuthorUser = authorId,
                IdTargetUser = targetId,
                EvaluateList = evaluateList
            };
            _feedbackModelDataAccess.Save(feedback);
            return feedback;
        }

    }
}
