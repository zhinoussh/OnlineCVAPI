using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCVAPI.Models
{
    public class Education : TEntity
    {
        public string institute { get; set; }
        
        [StringLength(10)]
        public string graduationYear { get; set; }
        public int CVId { get; set; }   
        
        [ForeignKey("CVId")]
        public CV cv { get; set; }
    }
}