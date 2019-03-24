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
    public class UserController : BaseController
    {
        private UserBusiness _userBusiness;

        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [SwaggerOperation(Summary = "Get information of Current User")]
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(long id)
        {
            try
            {
                User user = _userBusiness.GetById(id);
                return Ok(new UserDTO(user));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


    }
}
