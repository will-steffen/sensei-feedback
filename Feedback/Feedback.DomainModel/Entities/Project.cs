using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.DomainModel.Entities
{
    [Table("project")]
    public class Project : BaseModel
    {
        [Column("txt_name")]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
