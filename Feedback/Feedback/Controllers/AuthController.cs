using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Business.Entities;
using Feedback.DomainModel.Entities;
using Feedback.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Feedback.Controllers
{
    public class AuthController : BaseController
    {
        private UserBusiness _userBusiness;

        public AuthController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [SwaggerOperation(Summary = "Authenticate User")]
        [HttpPost]
        public ActionResult<LoginResponseDTO> Post([FromBody] LoginRequestDTO dto)
        {
            try
            {
                User user = _userBusiness.Authenticate(dto.username, dto.password);
                return Ok(new LoginResponseDTO { userId = user.Id });
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
