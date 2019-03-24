using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Business.Entities;
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
        private CompetenceBusiness _competenceBusiness;

        public CompetenceController(CompetenceBusiness competenceBusiness)
        {
            _competenceBusiness = competenceBusiness;
        }

        [SwaggerOperation(Summary = "Get the Competence List")]
        [HttpGet]
        public ActionResult<IEnumerable<CompetenceDTO>> Get()
        {
            List<Competence> compList = _competenceBusiness.List().ToList();
            return Ok(compList.Select(x => new CompetenceDTO(x)));
        }
    }
}
