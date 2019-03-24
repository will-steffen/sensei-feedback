using Feedback.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.DomainModel.Entities
{
    [Table("competence")]
    public class Competence : BaseModel
    {
        [Column("txt_name")]
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [Column("txt_username")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("cd_role")]
        public Role Role { get; set; }
    }
}
