using Feedback.DomainModel;
using Feedback.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback.DataAccess.Entities
{
    public class FeedbackModelDataAccess : BaseDataAccess<FeedbackModel>
    {
        public FeedbackModelDataAccess(ApplicationContext ctx) : base(ctx) { }

        public override IQueryable<FeedbackModel> GetBaseQueryable()
        {
            return Context.Feedback          
                .Include(x => x.EvaluateList);
        }

        public FeedbackModel GetByUsersIds(long authorId, long targetId)
        {
            return GetBaseQueryable().Where(x => x.IdAuthorUser == authorId && x.IdTargetUser == targetId).FirstOrDefault();
        }

    }
}
