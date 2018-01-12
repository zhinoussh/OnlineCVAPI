using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCVAPI.Models
{
    public class Experience : TEntity
    {
        [StringLength(50)]
        [Required]
        public string jobTitle { get; set; }

        [StringLength(50)]
        [Required]        
        public string Employer { get; set; }
        
        [StringLength(50)]
        [Required]        
        public string Location { get; set; }
        
        [StringLength(4)]
        [Required]        
        public string startMonth { get; set; }
        
        [StringLength(4)]
        [Required]        
        public string startYear { get; set; }

        [StringLength(4)]
        public string endMonth { get; set; }
        
        [StringLength(4)]
        public string endYear { get; set; }
        public bool stillInRole { get; set; }
        public int CVId {get; set;}
        
        [ForeignKey("CVId")]
        public CV cv { get; set; }
    }
}