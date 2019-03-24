using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Feedback.DomainModel.Entities
{
    public class LinkUserProject
    {
        [Column("id_user")]
        public long IdUser { get; set; }

        [ForeignKey("IdUser")]
        [InverseProperty("ProjectList")]
        public virtual User User { get; set; }

        [Column("id_project")]
        public long IdProject { get; set; }

        [ForeignKey("IdProject")]
        public virtual Project Project { get; set; }
    }
}
