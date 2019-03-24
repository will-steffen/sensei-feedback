using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.DomainModel.Entities
{
    [Table("user")]
    public class User : BaseModel
    {
        [Column("txt_name")]
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [Column("txt_username")]
        [StringLength(250)]
        [Required]
        public string Username { get; set; }

        [Column("txt_email")]
        [StringLength(250)]
        [Required]
        public string Email { get; set; }

        [Column("txt_hash_password")]
        [StringLength(250)]
        public string HashPassword { get; set; }

        [Column("txt_salt")]
        [StringLength(250)]
        public string Salt { get; set; }

        [Column("cd_role")]
        [Required]
        public Role Role { get; set; }

        [Column("id_manager_user")]
        public long? IdManagerUser { get; set; }

        [ForeignKey("IdManagerUser")]
        public virtual User ManagerUser { get; set; }

        public virtual List<LinkUserProject> ProjectList { get; set; }
    }
}
