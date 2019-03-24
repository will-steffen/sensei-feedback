using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Entities
{
    public class CompetenceDTO : BaseModelDTO
    {
        public string name { get; set; }
        public string description { get; set; }

        public CompetenceDTO() { }

        public CompetenceDTO(Competence model) : base(model)
        {
            name = model.Name;
            description = model.Description;
        }
    }
}
