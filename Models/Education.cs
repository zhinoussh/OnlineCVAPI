using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCVAPI.Models
{
    public class Education : TEntity
    {
        [StringLength(50)]
        [Required]
        public string institute { get; set; }
        
        [StringLength(10)]
        [Required]
        public string graduationYear { get; set; }
        public int CVId { get; set; }   
        
        [ForeignKey("CVId")]
        public CV cv { get; set; }
    }
}