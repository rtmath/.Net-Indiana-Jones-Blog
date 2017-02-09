using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndianaJonesBlog.Models
{
    [Table("ExperiencesPersons")]
    public class ExperiencePerson
    {

        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }

        public ExperiencePerson(int newExperienceId, int newPersonId)
        {
            ExperienceId = newExperienceId;
            PersonId = newPersonId;
        }
    }
}
