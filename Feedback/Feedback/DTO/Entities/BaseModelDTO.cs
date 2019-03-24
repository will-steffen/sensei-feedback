using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Entities
{
    public class BaseModelDTO
    {
        public long id { get; set; }
        public DateTime createDate { get; set; }

        public BaseModelDTO() { }

        public BaseModelDTO(BaseModel model)
        {
            id = model.Id;
            createDate = model.CreateDate;
        }
    }
}
