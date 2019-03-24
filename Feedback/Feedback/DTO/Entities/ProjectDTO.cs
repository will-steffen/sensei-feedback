using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Entities
{
    public class ProjectDTO : BaseModelDTO
    {
        public string name { get; set; }

        public ProjectDTO() { }

        public ProjectDTO(Project model) : base(model)
        {
            name = model.Name;
        }
    }
}
