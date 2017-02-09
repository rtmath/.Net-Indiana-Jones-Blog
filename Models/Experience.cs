using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndianaJonesBlog.Models
{
    [Table("Experiences")]
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<ExperiencePerson> ExperiencesPersons { get; set; }
    }
}
