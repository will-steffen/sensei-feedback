using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Request
{
    public class LoginResponseDTO
    {
        public string accessToken { get; set; }
        public long userId { get; set; }
    }
}
