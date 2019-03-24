using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.DomainModel.Entities
{
    [Table("evaluate")]
    public class Evaluate : BaseModel
    {
        [Column("cd_rate")]
        public Rate Rate { get; set; }

        [Column("txt_comment")]
        [StringLength(500)]
        public string Comment { get; set; }


        [Column("id_competence")]
        public long IdCompetence { get; set; }

        [ForeignKey("IdCompetence")]
        public virtual Competence Competence { get; set; }


        [Column("id_feedback")]
        public long IdFeedback { get; set; }

        [ForeignKey("IdFeedback")]
        public virtual FeedbackModel Feedback { get; set; }
   
    }
}
