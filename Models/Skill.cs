using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCVAPI.Models
{
    public class Skill : TEntity
    {
        public string skillName { get; set; }
        public string Institute { get; set; }
        public string year { get; set; }
        public int CVId { get; set; }

        [ForeignKey("CVId")]
        public CV cv {get; set;}
    }
}