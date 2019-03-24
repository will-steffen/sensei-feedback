using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Feedback.Controllers
{
    public class AuthController : BaseController
    {

        [SwaggerOperation(Summary = "Verify if accessToken is valid")]
        [HttpGet]
        public ActionResult<bool> Get()
        {
            return true;
        }

        [SwaggerOperation(Summary = "Authenticate User")]
        [HttpPost]
        public ActionResult<LoginResponseDTO> Post([FromBody] LoginRequestDTO dto)
        {
            return Ok(new LoginResponseDTO { accessToken = "nygwfyg34necr-3vr-3c54f345fv" });
        }

    }
}
