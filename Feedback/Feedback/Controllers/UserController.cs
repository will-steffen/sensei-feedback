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
    public class UserController : BaseController
    {
        [SwaggerOperation(Summary = "Get information of Current User")]
        [HttpGet]
        public ActionResult<UserDTO> Get()
        {
            User user = new User
            {
                Id = 1,
                Name = "A Greate User",
                Username = "user",
                Email = "user@sensei-fedback.com",
                Role = Role.Engineer,
                IdManagerUser = 2,
            };
            return Ok(new UserDTO());
        }


    }
}
