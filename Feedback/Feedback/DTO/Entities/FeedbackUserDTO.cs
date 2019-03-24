using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Entities
{
    public class FeedbackUserDTO
    {
        public string name { get; set; }
        public Role role { get; set; }
        public float averageRate { get; set; }
        public long idFeedback { get; set; }

        public FeedbackUserDTO() { }    

        public FeedbackUserDTO(User user, FeedbackModel feedback = null)
        {
            name = user.Name;
            role = user.Role;
            averageRate = 0;
            if (feedback != null)
            {
                if (feedback.EvaluateList != null)
                    averageRate = feedback.EvaluateList.Sum(x => (int)x.Rate) / feedback.EvaluateList.Count;
                idFeedback = feedback.Id;
            }
        }
    }
}
