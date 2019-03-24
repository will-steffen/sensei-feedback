using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Entities
{
    public class EvaluateDTO : BaseModelDTO
    {
        public Rate rate { get; set; }
        public string comment { get; set; }
        public long idCompetence { get; set; }

        public EvaluateDTO() { }

        public EvaluateDTO(Evaluate model) : base(model)
        {
            rate = model.Rate;
            comment = model.Comment;
            idCompetence = model.IdCompetence;
        }
    }
}
