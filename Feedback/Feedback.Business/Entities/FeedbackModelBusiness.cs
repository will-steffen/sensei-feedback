﻿using Feedback.DataAccess.Entities;
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
            return relatedUsers.Select(x => new Tuple<User, FeedbackModel>(x, null)).ToList();
        }

    }
}
