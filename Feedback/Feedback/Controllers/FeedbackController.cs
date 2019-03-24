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
    public class FeedbackController : BaseController
    {
        

        private FeedbackSeasonBusiness _feedbackSeasonBusiness;
        private FeedbackModelBusiness _feedbackModelBusiness;

        public FeedbackController(
            FeedbackSeasonBusiness feedbackSeasonBusiness,
            FeedbackModelBusiness feedbackModelBusiness

        ) {
            _feedbackSeasonBusiness = feedbackSeasonBusiness;
            _feedbackModelBusiness = feedbackModelBusiness;
        }


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
            try
            {
                FeedbackModel feddback = _feedbackModelBusiness.GetById(id);
                return Ok(new FeedbackDTO(feddback));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [SwaggerOperation(Summary = "Save a new Feedback")]
        [HttpPost]
        public ActionResult Post([FromBody] SaveFeedbackRequestDTO dto)
        {
            return Ok();
        }


        [SwaggerOperation(Summary = "Get the current FeedbackSeason, of it exists")]
        [HttpGet("season")]
        public ActionResult<FeedbackSeasonDTO> GetSeason()
        {
            try
            {
                return Ok(new FeedbackSeasonDTO(_feedbackSeasonBusiness.GetCurrent()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [SwaggerOperation(Summary = "Get the list of Seasons")]
        [HttpGet("season-list")]
        public ActionResult<IEnumerable<FeedbackSeasonDTO>> GetSeasonList()
        {
            try
            {
                return Ok(_feedbackSeasonBusiness.List().ToList().Select(x => new FeedbackSeasonDTO(x)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
