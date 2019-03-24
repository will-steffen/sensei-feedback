using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.DomainModel;
using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using Feedback.DTO.Entities;
using Feedback.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Feedback.Controllers
{
    public class CompetenceController : BaseController
    {
        [SwaggerOperation(Summary = "Get the Competence List")]
        [HttpGet]
        public ActionResult<IEnumerable<CompetenceDTO>> Get()
        {
            List<Competence> compList = new List<Competence>
            {
                new Competence
                {
                    Id = 1,
                    Name = "Communication",
                    Description = "Is this person a good Communicator?"
                },
                new Competence
                {
                    Id = 1,
                    Name = "Leader",
                    Description = "Is this person a good Leader?",
                    Role = Role.Manager
                },
            };
            return Ok(compList.Select(x => new CompetenceDTO(x)));
        }
    }
}
