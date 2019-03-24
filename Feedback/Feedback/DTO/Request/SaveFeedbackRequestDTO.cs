using Feedback.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Request
{
    public class SaveFeedbackRequestDTO
    {
        public long targetId { get; set; }
        public long authorId { get; set; }
        public string comment { get; set; }
        public List<EvaluateDTO> evaluateList { get; set; }
    }
}
