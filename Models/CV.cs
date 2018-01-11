using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCVAPI.Models
{
    public class CV
    {
        public CV()
        {
            Skills=new HashSet<Skill>();
            Educations=new HashSet<Education>();
            Experiences=new HashSet<Experience>();
        }
        [Key]
        public int Id { get; set; }
        public int profileId { get; set; }
        public int templateId { get; set; }
        public string creationDateTime { get; set; }
        
        [ForeignKey("profileId")]
        public PersonalProfile profile { get; set; }
        
        [ForeignKey("templateId")]
        public CVTemplate template { get; set; }
        public ICollection<Skill> Skills {get; set;}
        public ICollection<Education> Educations {get; set;}
        public ICollection<Experience> Experiences {get; set;}

    }
}