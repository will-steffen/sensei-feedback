using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.DomainModel.Entities
{
    [Table("feedback")]
    public class Feedback : BaseModel
    {
        [Column("id_author_user")]
        public long IdAuthorUser { get; set; }

        [ForeignKey("IdAuthorUser")]
        public virtual User AuthorUser { get; set; }



        [Column("id_target_user")]
        public long IdTargetUser { get; set; }

        [ForeignKey("IdTargetUser")]
        public virtual User TargetUser { get; set; }



        [Column("id_project")]
        public long IdProject { get; set; }

        [ForeignKey("IdProject")]
        public virtual Project Project { get; set; }



        [Column("id_feedback_season")]
        public long IdFeedbackSeason { get; set; }

        [ForeignKey("IdFeedbackSeason")]
        public virtual FeedbackSeason FeedbackSeason { get; set; }



        public virtual List<Evaluate> EvaluateList { get; set; }
    }
}
