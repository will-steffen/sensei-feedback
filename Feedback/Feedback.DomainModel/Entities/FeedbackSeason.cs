using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.DomainModel.Entities
{
    [Table("feedback_season")]
    public class FeedbackSeason : BaseModel
    {
        [Column("dt_start")]
        public DateTime StartDate { get; set; }

        [Column("dt_end")]
        public DateTime EndDate { get; set; }

        public virtual List<FeedbackModel> FeedbackList { get; set; }

    }
}
