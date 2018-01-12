using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCVAPI.Models
{
    public class Skill : TEntity
    {
        [StringLength(50)]
        public string skillName { get; set; }

        [StringLength(50)]
        public string Institute { get; set; }

        [StringLength(10)]
        public string year { get; set; }
        
        public int CVId { get; set; }

        [ForeignKey("CVId")]
        public CV cv {get; set;}
    }
}