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
    public class FeedbackController : BaseController
    {
        [SwaggerOperation(
            Summary = "Get Feedback UserList",
            Description = "Get a list of User the current User have to evaluate")]
        [HttpGet]
        public ActionResult<IEnumerable<FeedbackUserDTO>> Get()
        {
            List<User> compList = new List<User>
            {
                new User
                {
                    Id = 2,
                    Name = "Manager",
                    Role = Role.Manager
                },
                new User
                {
                    Id = 3,
                    Name = "Colleague",
                    Role = Role.Engineer,
                    IdManagerUser = 2,
                },
                new User
                {
                    Id = 4,
                    Name = "Intern",
                    Role = Role.Intern,
                    IdManagerUser = 1,
                }
            };
            return Ok(compList.Select(x => new FeedbackUserDTO(x)));
        }

        [SwaggerOperation(Summary = "Get Feedback details by FeedbackId")]
        [HttpGet("{id}")]
        public ActionResult<FeedbackDTO> GetById(long id)
        {
            return Ok(new FeedbackDTO(new FeedbackModel
            {
            }));
        }

        [SwaggerOperation(Summary = "Save a new Feedback")]
        [HttpPost]
        public ActionResult Post([FromBody] SaveFeedbackRequestDTO dto)
        {
            return Ok();
        }
    }
}
