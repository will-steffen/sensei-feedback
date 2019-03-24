using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Entities
{
    public class FeedbackSeasonDTO : BaseModelDTO
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public FeedbackSeasonDTO() { }

        public FeedbackSeasonDTO(FeedbackSeason model) : base(model)
        {
            startDate = model.StartDate;
            endDate = model.EndDate;
        }
    }
}
