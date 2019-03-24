using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Entities
{
    public class FeedbackDTO : BaseModelDTO
    {
        public UserDTO authorUser { get; set; }
        public UserDTO targetUser { get; set; }
        public ProjectDTO project { get; set; }
        public FeedbackSeasonDTO feedbackSeason { get; set; }
        public List<EvaluateDTO> evaluateList { get; set; }
        public string comment { get; set; }

        public FeedbackDTO() { }

        public FeedbackDTO(FeedbackModel model) : base(model)
        {
            comment = model.Comment;
            if(model.AuthorUser != null) authorUser = new UserDTO(model.AuthorUser);
            if(model.TargetUser != null) targetUser = new UserDTO(model.TargetUser);
            if(model.Project != null) project = new ProjectDTO(model.Project);
            if(model.FeedbackSeason != null) feedbackSeason = new FeedbackSeasonDTO(model.FeedbackSeason);
            if (model.EvaluateList != null) evaluateList = model.EvaluateList.Select(x => new EvaluateDTO(x)).ToList();
        }
    }
}
