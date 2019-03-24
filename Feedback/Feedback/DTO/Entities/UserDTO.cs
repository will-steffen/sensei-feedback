using Feedback.DomainModel.Entities;
using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.DTO.Entities
{
    public class UserDTO : BaseModelDTO
    {
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Role role { get; set; }
        public long? idManagerUser { get; set; }

        public UserDTO() { }

        public UserDTO(User model) : base(model)
        {
            name = model.Name;
            username = model.Username;
            email = model.Email;
            role = model.Role;
            idManagerUser = model.IdManagerUser;
        }

        public UserDTO(User model, bool simplified)
        {
            id = model.Id;
            name = model.Name;
            role = model.Role;
            idManagerUser = model.IdManagerUser;
        }
    }
}
